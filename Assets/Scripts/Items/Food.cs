using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Food")]
public class Food : Item
{
    protected override void Start()
    {
        base.Start();
        setType(ItemType.Food);
    }
    public override void use(string itemType = null){
        
        HungerController.instance.eat();        
    }

}
