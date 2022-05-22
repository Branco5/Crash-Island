using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendTalk : Interactable
{
    public Dialogue intro;
    public Dialogue dialogue;
    public bool introductionDone = false;
    public GameObject dialoguePanel;

    protected override void interact(){
        base.interact();
        GetComponent<ConvoRotationController>().hasGreeted=true;
        GetComponent<Animator>().SetTrigger("TriggerTalk");
        Player.instance.GetComponent<Animator>().SetTrigger("TriggerTalk");
        triggerDialogue();
        dialoguePanel.SetActive(true);        
    }

    public void triggerDialogue(){
        if(!introductionDone){
           DialogueManager.instance.startDialogue(intro);  
        }
        else{
           DialogueManager.instance.startDialogue(dialogue);  
        }
    }
}
