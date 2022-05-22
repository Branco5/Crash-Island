using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoRotationController : MonoBehaviour
{
    Quaternion targetRotation;
    Quaternion playerTargetRot;
    public bool hasGreeted = false;
    public GameObject dialoguePanel;
    
       
    void Update()
    {
        targetRotation = Quaternion.LookRotation(Player.instance.transform.position - transform.position);
        playerTargetRot = Quaternion.LookRotation(transform.position-Player.instance.transform.position);
        // Turn characters towards eaxh other
        if(hasGreeted){
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2*Time.deltaTime);
            Player.instance.transform.rotation = Quaternion.Slerp(Player.instance.transform.rotation, playerTargetRot, 2*Time.deltaTime);
           
            if(!dialoguePanel.activeSelf){                
                hasGreeted=false;                                
            }
        }        
    }

}
