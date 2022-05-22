using Assets.Scripts.ItemFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Wood")]
public class Wood : Ingredient
{
    protected override void Start(){
        base.Start();
        setType(ItemType.Wood);
    }
    public override void use(string itemType = null)
    {
        base.use("wood");
    }


}
