using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    public Item item;
    public Image icon;
    public void addItem(Item newItem){  
        item=newItem;
        icon.sprite=item.icon;
        icon.enabled=true;
    }


    public void clearItem(){        
        item = null;
        icon.sprite=null;
        icon.enabled=false;
    }

    public void onDropPressed(){        
        Inventory.instance.add(item);
        CraftTable.instance.remove(item);
    }
}

