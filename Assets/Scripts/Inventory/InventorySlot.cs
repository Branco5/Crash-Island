using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public Image icon;
    public Button dropButton;
    public Text countText;

    public void addItem(Item newItem){  
        item=newItem;
        icon.sprite=item.icon;
        icon.enabled=true;
        dropButton.interactable=true;
        countText.text=newItem.quantity.ToString();
    }

    public void clearItem(){        
        item = null;
        icon.sprite=null;
        icon.enabled=false;
        dropButton.interactable=false;
        countText.text="";
    }

    public void onDropPressed(){
       Inventory.instance.remove(item);
    }

    IEnumerator exit() 
    {
        yield return new WaitForSeconds(3);   
        Inventory.instance.remove(item);
    }

    public void onUsePressed(){
        if(item != null ){
            item.use(); 
            if(item is Food){
                Inventory.instance.remove(item);
            }
        }
    }
}
