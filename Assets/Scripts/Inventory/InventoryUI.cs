using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    InventorySlot[] slots;
    Inventory inventory;
    public GameObject inventoryPanel;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChange += updateUI;
        slots=itemsParent.GetComponentsInChildren<InventorySlot>();
    }   

    void Update(){
        if(Input.GetKeyDown(KeyCode.I)){
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
    void updateUI(){
        for (int i = 0; i < slots.Length; i++)
        {
            if(i<inventory.items.Count){
                slots[i].addItem(inventory.items[i]);
            }
            else
            {
                slots[i].clearItem();
            }
        }
    }
}
