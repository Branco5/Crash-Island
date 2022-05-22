using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    #region Singleton
    public static DialogueManager instance;
    void Awake(){
        if(instance!=null){
            Debug.LogWarning("At least one instance of DialogueManager already running");
            //return;
        }
        instance = this;
    }  
    #endregion 
    public Queue<string> phrases;    
    public Text nameText;
    public Text dialogueText;
    public Text warningText;
    public GameObject dialoguePanel;
    public GameObject warningPanel;
    
    void Start()
    {
        phrases = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue){
        phrases.Clear();

        nameText.text = dialogue.characterName;

        foreach(string phrase in dialogue.phrases){
            phrases.Enqueue(phrase);
        }

        displayPhrase();
    }

    public void startWarning(string text){
        phrases.Clear();
        warningText.text = text;
        warningPanel.SetActive(true);
    }

    public void closeWarningPanel(){
        warningPanel.SetActive(false);
    }

    public void displayPhrase(){
        if (phrases.Count==0){
            dialoguePanel.SetActive(false);
            Player.instance.isInteracting=false;
            return;
        }

        string phrase = phrases.Dequeue();
        dialogueText.text = phrase;
    }
}
