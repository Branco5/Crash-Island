using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new tool", menuName = "Items/Tools/Pickaxe")]
public class Pickaxe : Tool
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        setType(ItemType.Pickaxe);
    }

}
