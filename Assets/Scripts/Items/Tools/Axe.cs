using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new tool", menuName = "Items/Tools/Axe")]
public class Axe : Tool
{
    

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        setType(ItemType.Axe);
    }

   
}
