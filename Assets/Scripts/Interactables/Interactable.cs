using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    bool interactButtonPressed = false;
    Transform player;
    
    protected virtual void interact(){
        Debug.Log("INTERACTING");
    }
  

    protected virtual void Update(){
        if(interactButtonPressed){        
            interactButtonPressed=false; 
            interact();                       
        }        
    }

    public void onInteract(){
        interactButtonPressed = true;
    }
    
}
