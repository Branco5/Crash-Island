using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool PlayerIsDead = false;

    public GameObject PauseMenuUI;
    public GameObject DeathScreenUI;

    public GameObject VictoryScreenUI;


   void Update() {
    if(Input.GetKeyDown(KeyCode.Escape)){
        if(GameIsPaused && !Player.instance.isDead){
            Resume();
        } else if(!Player.instance.isDead){
            Pause();
            }
        }    
    }
    public void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartGame(){
        Player.instance.isDead=false;
        Player.instance.isInteracting=false;
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void DeathScreen(){
        Invoke("ShowDeathScreen",2.5f);
    }

    public void ShowDeathScreen(){
        DeathScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowVictoryScreen(){
        VictoryScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitToMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    
    public void QuitToDesktop(){
        Time.timeScale = 1f;
        Application.Quit();
    }
}
