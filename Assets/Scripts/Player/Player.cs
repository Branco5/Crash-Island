using Assets.Scripts.ItemFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    #region Singleton
    public static Player instance;
    void Awake(){
        if(instance!=null){
            Debug.LogWarning("At least one instance of Player already running");
            //return;
        }
        instance = this;
    }  
    #endregion  
    public float health = 10;
    public float maxHealth = 10;
    private Rigidbody rb;
    private Animator anim;
    public ConvoRotationController convoController;
    public Interactable interactable=null;
    public bool isInteracting=false;
    public bool isDead;

    public GameObject interactingWith;

    public PauseMenu pauseMenu;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();    
        convoController = GetComponent<ConvoRotationController>(); 
        isDead = false;  
        
    }

    // Update is called once per frame
   void Update ()    {     
       if(!isDead){
            if(health <= 0){
                anim.SetTrigger("TriggerDeath");
                isDead=true;
                pauseMenu.DeathScreen();
            }    
        }
    }
    public void takeDamage(float hitPoints){
        health-=hitPoints;
    } 

    void attack(Collider other){
        other.gameObject.GetComponent<WolfController>().takeDamage();
    } 

    public void restoreHealth(){
        health=maxHealth;
    }
    //ANIMATION EVENT
    void step(){
        AudioManager.instance.Play("Walking");
    }
    //ANIMATION EVENT
    void chop(){
    if(!isDead){
        Tree tree = interactingWith.GetComponent<Tree>();
        if(tree!=null){
            tree.decreaseHealth();
            AudioManager.instance.Play("WoodCutting");
            Inventory.instance.add(ItemFactory.instance.getItem("wood"));
            ToolManager.instance.equipped.decreaseHealth();
            return;
        }  
        StoneObj stoneObj = interactingWith.GetComponent<StoneObj>();
        if(stoneObj!=null){
            stoneObj.decreaseHealth();

            AudioManager.instance.Play("Mining");

            Inventory.instance.add(ItemFactory.instance.getItem("stone"));
            ToolManager.instance.equipped.decreaseHealth();
            return;
        }    
        WolfController wolf = interactingWith.GetComponent<WolfController>();
        if(wolf!=null){
            AudioManager.instance.Play("Stab");
            ToolManager.instance.equipped.decreaseHealth();
            return;
        }   
    }
}

    //ANIMATION EVENT
    void playReelSound(){        
        AudioManager.instance.Play("Fishing");        
    }

    //ANIMATION EVENT
    void fish(){
        Fishing fish = interactingWith.GetComponent<Fishing>();
        if(fish!=null){            
            Inventory.instance.add(ItemFactory.instance.getItem("food"));
            ToolManager.instance.equipped.decreaseHealth();
        }  
    }

    void OnTriggerStay(Collider other){
        if(!isInteracting && !isDead){
            if(Input.GetKey(KeyCode.E)){
                interactingWith=other.gameObject; 
                interactable = other.gameObject.GetComponent<Interactable>();  
                  
                if(interactable!=null){       
                    isInteracting=true;                             
                    interactable.onInteract();                
                }  
            }  

        }          
            
    }
            
       

     

        
}

