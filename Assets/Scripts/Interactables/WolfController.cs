using Assets.Scripts.ItemFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : Interactable
{
    Rigidbody rb;
    Animator anim;
    private bool touchingPlayer=false;
    private bool playerDetected=false;
    public float detectionRadius = 10f;
    public float runSpeed = 4f;
    public Player player;
    public float attackCooldown = 0f;
    public int health = 5;
    public float despawnTime=30f;
    private bool playerAttacking = false;
    public float playerAttackCooldown = 0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); 
        player = Player.instance;
    }

    protected override void interact()
    {
        base.interact();
        if(health>0){
            Item tool = ToolManager.instance.equipped;
            if(tool==null || tool.getType() == ItemType.FishCane){
                DialogueManager.instance.startWarning("You don't have the right equipment for this interaction");
                Player.instance.isInteracting=false;
            }
            else{
                playerAttacking=true;
                Player.instance.GetComponent<Animator>().SetBool("BoolChop", true);
                Player.instance.transform.LookAt(transform);
                StartCoroutine("exit");
            }
        }
        else{
            bool result = Inventory.instance.add(ItemFactory.instance.getItem("food"));
            if(result==true){
                Animator anim = player.GetComponent<Animator>();
                anim.SetTrigger("TriggerPickup");
                anim.SetTrigger("TriggerIdle");            
                Destroy(gameObject); 
            }            
            player.isInteracting=false;  
        }            
    }

    IEnumerator exit() 
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.anyKey || health<=0 || player.health<=0);
        playerAttacking=false;
        player.GetComponent<Animator>().SetBool("BoolChop", false);
        player.isInteracting=false;
    }

    // Update is called once per frame
    protected override void Update()
    {        
        base.Update();
        if(health>0){           
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if(distance<=detectionRadius && touchingPlayer==false){
                anim.SetBool("BoolChasing", true);
                transform.LookAt(player.transform);
                transform.position+= transform.forward * runSpeed * Time.deltaTime;
                playerDetected=true;
            }
            else if(distance>detectionRadius && playerDetected==true){
                playerDetected=false;
                anim.SetBool("BoolChasing", false);
            }   
        }
        else{
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Die")){
                anim.SetTrigger("TriggerDeath");
            }            
            if(despawnTime>0){
                despawnTime-=Time.deltaTime;
            }
            else{
                Destroy(gameObject);
            }
        }             
    }
    void OnTriggerStay(Collider other){
        if (health>0 && other.gameObject.CompareTag("Player")) { 
            Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>());
            touchingPlayer = true;
            anim.SetBool("BoolAttacking", true);
            attack(player);    
            attackCooldown-=Time.deltaTime;        
        }
        if(playerAttacking==true){
            playerAttack();
            playerAttackCooldown-=Time.deltaTime;
        }
    }

    void OnTriggerExit(){
        touchingPlayer = false;
        anim.SetBool("BoolAttacking", false);
    }

    void attack(Player pc){
        if(attackCooldown<=0){
            pc.takeDamage(1);
            attackCooldown+=1;            
        }        
    }

    void playerAttack(){
        if(playerAttackCooldown<=0){
            takeDamage();
            playerAttackCooldown+=2f;            
        }        
    }

    public void takeDamage(){
        health-=1;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
