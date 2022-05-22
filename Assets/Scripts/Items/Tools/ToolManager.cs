using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    #region Singleton
    public static ToolManager instance;
    void Awake(){
        if(instance!=null){
            Debug.LogWarning("At least one instance of ToolManager already running");
            return;
        }
        instance = this;
    }  
    #endregion
    public Tool equipped;
    public Inventory inventory;
    public void Start(){
        equipped=null;
        inventory=Inventory.instance;
    }
    public void equip(Tool tool){
        Tool oldTool = null;
        bool alreadyInstantiated = tool.onEquip();
        if(equipped!=null){
            oldTool = equipped;
            inventory.add(oldTool);              
        }        
        equipped=tool;        
    }

    public void unequip(){
        if(equipped!=null){            
            inventory.add(equipped);            
            equipped=null;            
        } 
    }
}
