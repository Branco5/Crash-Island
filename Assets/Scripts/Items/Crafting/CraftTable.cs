using Assets.Scripts.ItemFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftTable : MonoBehaviour
{
    #region Singleton
    public static CraftTable instance;



    public PauseMenu pauseMenu;

    void Awake(){
        if(instance!=null){
            Debug.LogWarning("At least one instance of CraftTable already running");
            return;
        }
        instance = this;
    }  
    #endregion  

    public List<Item> items = new List<Item>();
    public int space = 3;
    public delegate void OnItemChange();
    public OnItemChange onItemChange;

    
    public bool add(Item item){        

        if(items.Count>=space){   
            Debug.Log("Craft Table full");
            return false;
        }
        
        Inventory.instance.remove(item);  
        items.Add(item); 
        onItemChange.Invoke();

        return true;
    }

    public void craft(){
        if(countItemsOfType(ItemType.Stone)==1 && countItemsOfType(ItemType.Wood)==2){
            Inventory.instance.add(ItemFactory.instance.getItem("axe"));
        }
        else if(countItemsOfType(ItemType.Stone)==2 && countItemsOfType(ItemType.Wood)==1){           
            Inventory.instance.add(ItemFactory.instance.getItem("pickaxe"));            
        }
        else if(countItemsOfType(ItemType.Wood)==3){           
            Inventory.instance.add(ItemFactory.instance.getItem("fishcane"));            
        }
        else if(countItemsOfType(ItemType.RadioPiece)==3){          
            pauseMenu.ShowVictoryScreen();  
        }
        else{
            DialogueManager.instance.startWarning("Recipe not valid");
            return;
        }
        items.Clear();
        onItemChange.Invoke();
    }

    int countItemsOfType(ItemType type){
        int count = 0;
        foreach (Item item in items)
        {
            if(item.type==type){
                count++;
            }
        }
        return count;
    }

    public void remove(Item item){        
        items.Remove(item);             
        
        onItemChange.Invoke();
    }

    public int countItemInList(Item item){
        int count =0;
        for(int i =0; i<items.Count; i++){
            if(item==items[i]){
                count++;
            }
        }
        return count;
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
