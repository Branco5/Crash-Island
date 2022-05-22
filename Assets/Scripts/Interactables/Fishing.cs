using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : Interactable
{
    protected override void interact(){
        base.interact();
        Player.instance.GetComponent<Animator>().SetBool("BoolFishingCast", true);
        StartCoroutine("exit");
    }

    IEnumerator exit() 
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.anyKey);
        Player.instance.GetComponent<Animator>().SetBool("BoolFishingCast", false);
        Player.instance.isInteracting=false;
    }


}