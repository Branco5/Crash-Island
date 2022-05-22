using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftUI : MonoBehaviour
{
    public Transform itemsParent;
    CraftSlot[] slots;
    CraftTable table;
    public GameObject craftPanel;
    void Start()
    {
        table = CraftTable.instance;
        table.onItemChange += updateUI;
        slots=itemsParent.GetComponentsInChildren<CraftSlot>();
    }   

    void updateUI(){
        for (int i = 0; i < slots.Length; i++)
        {
            if(i<table.items.Count){
                slots[i].addItem(table.items[i]);
            }
            else
            {
                slots[i].clearItem();
            }
        }
    }
}

