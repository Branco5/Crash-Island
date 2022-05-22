using UnityEngine;

public class ItemPickup : Interactable
{    
    public Item item;
    public Player player;
    void Start(){
        player=Player.instance;
    }
    protected override void interact(){
        base.interact();
        bool result = Inventory.instance.add(item);
        if(result==true){
            Animator anim = player.GetComponent<Animator>();
            anim.SetTrigger("TriggerPickup");
            anim.SetTrigger("TriggerIdle");            
            Destroy(gameObject); 
        }
        
        player.isInteracting=false;       
    }
}
