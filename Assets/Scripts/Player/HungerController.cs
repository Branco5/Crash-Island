using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerController : MonoBehaviour
{
    #region Singleton
    public static HungerController instance;
    void Awake(){
        if(instance!=null){
            Debug.LogWarning("At least one instance of HungerController already running");
            return;
        }
        instance = this;
    }  
    #endregion
    static float HUNGER_COUNT = 30f;
    static float DMG_COUNT = 10f;

    Player player;
    public float hungerCountdown = HUNGER_COUNT;
    public float hungerDmgCountdown = DMG_COUNT;
    bool hasEaten = true;

    void Start(){
        player = Player.instance;
    }

    void Update(){
        if(hasEaten){
            hungerCountdown-=Time.deltaTime;
            if(hungerCountdown<=0){
                hasEaten=false;
            }
        }        
        else{
            hungerDmgCountdown-=Time.deltaTime;
            if(hungerDmgCountdown<=0){
                player.takeDamage(0.5f);
                hungerDmgCountdown+=DMG_COUNT;
            }
        }        
    }

    public void eat(){        
        hasEaten=true;
        hungerCountdown+=HUNGER_COUNT;
        player.restoreHealth();
    }
    
}
