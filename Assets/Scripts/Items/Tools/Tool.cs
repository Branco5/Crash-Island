using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new tool", menuName = "Items/Tools")]
public class Tool : Item
{
    public GameObject tool;
    public int health = 30;
    public override void use(string itemType = null)
    {
        base.use();
        ToolManager.instance.equip(this);
        Inventory.instance.remove(this);
    }
    public bool onEquip(){       
         
        GameObject hand = GameObject.Find("mixamorig:RightHand");
        Transform handTransform = hand.GetComponent<Transform>();
        
        foreach (Transform child in handTransform)
        {
            GameObject toolObject1 = child.gameObject;
            Tool toolChild = (Tool)toolObject1.GetComponent<ItemPickup>().item;
            if (toolChild.getType() == type){
                toolObject1.SetActive(true);
                deactivateObjects(handTransform);
                return true;
            }
        }
        Instantiate(tool, handTransform);
        deactivateObjects(handTransform);
        tool.transform.parent = handTransform;
        return false;
    }

    //Sets non equipped objects inactive
    void deactivateObjects(Transform transform){
        foreach (Transform child2 in transform){
            GameObject toolObject2 = child2.gameObject;
            Tool toolChild2 = (Tool)toolObject2.GetComponent<ItemPickup>().item;
            if (toolChild2.getType()!=type && toolObject2.activeSelf==true){
                toolObject2.SetActive(false);
                break;
            }
        }
    }

    public void decreaseHealth(){
        health--;
        if(health<=0){
            GameObject hand = GameObject.Find("mixamorig:RightHand");
            Transform handTransform = hand.GetComponent<Transform>();
            foreach (Transform child in handTransform)
            {
                GameObject toolObject1 = child.gameObject;
                Tool toolChild = (Tool)toolObject1.GetComponent<ItemPickup>().item;
                if (toolChild.getType() == type){
                    toolObject1.SetActive(false);
                    health=5;
                    Player.instance.GetComponent<Animator>().SetBool("BoolFishingCast", false);
                    Player.instance.GetComponent<Animator>().SetBool("BoolChop", false);
                    ToolManager.instance.equipped=null;
                }
            }
        }
    }


    public void onUnequip(){
        tool.SetActive(false);
    }

    
}
