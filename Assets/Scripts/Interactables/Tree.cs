using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Interactable
{
    static int TREE_HEALTH = 10;
    public int currentHealth = TREE_HEALTH;

    protected override void interact(){
        base.interact();
        Tool tool = ToolManager.instance.equipped;
        if(tool==null || tool.type!=ItemType.Axe){
            DialogueManager.instance.startWarning("You don't have the right equipment for this interaction");
            Player.instance.isInteracting=false;
        }
        else{
            Player.instance.GetComponent<Animator>().SetBool("BoolChop", true);
            var lookPos = transform.position - Player.instance.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            Player.instance.transform.rotation = rotation;

            StartCoroutine("exit");
        }        
    }

    IEnumerator exit() 
    {
        yield return new WaitForSeconds(1);   
        yield return new WaitUntil(() => Input.anyKey || currentHealth<=0);
        if(currentHealth<=0){
            Destroy(gameObject);
        }
        Player.instance.GetComponent<Animator>().SetBool("BoolChop", false);
        Player.instance.isInteracting=false;
    }

    public void decreaseHealth(){
        currentHealth--;
    }

    
}
