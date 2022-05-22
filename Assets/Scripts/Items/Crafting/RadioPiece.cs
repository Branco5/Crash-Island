using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Radio Piece")]
public class RadioPiece : Ingredient
{
    protected override void Start(){
        base.Start();
        setType(ItemType.RadioPiece);
    }
    public override void use(string itemType = null)
    {
        base.use("radioPiece");
    }
}