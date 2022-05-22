using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public int quantity;
    public Sprite icon;
    public ItemType type;
    
    protected virtual void Start(){
        quantity=1;
        type = ItemType.None;
    }
    public virtual void use(string itemType = null){
        Debug.Log("Using item " + name);       
    }

    public ItemType getType(){
        return type;
    }

    public void setType(ItemType type){
        this.type = type;
    }

    public void setQuantity(int qtd){
        quantity = qtd;
    }

}
