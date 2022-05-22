using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Stone")]
public class Stone : Ingredient
{
    protected override void Start(){
        base.Start();
        setType(ItemType.Stone);
    }
    public override void use(string itemType = null)
    {
        base.use("stone");
    }
}
