using Assets.Scripts.ItemFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Item
{
    public override void use(string item = null)
    {
        CraftTable.instance.add(ItemFactory.instance.getItem(item));
    }

}
