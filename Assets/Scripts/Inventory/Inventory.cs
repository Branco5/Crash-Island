using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Diagnostics;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake(){
        if(instance!=null){
            Debug.LogWarning("At least one instance of Inventory already running");
            return;
        }
        instance = this;
    }  
    #endregion  

    public List<Item> items = new List<Item>();
    public int space = 12;
    public delegate void OnItemChange();
    public OnItemChange onItemChange;


    
    public bool add(Item item){        
        if(items.Count>=space){   
            Debug.Log("Inventory full");
            return false;
        }
        if(items.Contains(item) || checkIfContainsEqualType(item)){
            foreach (Item item2 in items)
            {
                if(item2==item || item2.type==item.type){
                    item2.quantity++;
                    break;
                }
            }
        }
        else{
            item.setQuantity(1);
            items.Add(item);   
        }

        onItemChange.Invoke();
        
        return true;
    }

    public bool checkIfContainsEqualType(Item item){
        foreach (Item item2 in items)
        {
            if(item2.type==item.type){
                return true;
            }
        }
        return false;
            
    }

    public void remove(Item item){
        if(items.Contains(item) || checkIfContainsEqualType(item)){
            foreach (Item item2 in items)
            {
                if(item2==item || item2.type==item.type){
                    if(item2.quantity>1){
                        item2.quantity--;
                    }
                    else{
                        items.Remove(item2);
                    }  
                break;
                }
            }
        }             
        
        onItemChange.Invoke();
    }   
    

    public int countDistinct(){
        List<Item> itemsDistinct = new List<Item>();
        for (int i = 0; i < items.Count; i++)
        {
            if(!itemsDistinct.Contains(items[i])){
                itemsDistinct.Add(items[i]);
            }
        }

        return itemsDistinct.Count;
    }

}
