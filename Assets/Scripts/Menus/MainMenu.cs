using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{

    public GameObject SettingsUI;
    public GameObject MainMenuUI;

    public GameObject ControlsUI;

    public Dropdown resolutionDropdown;

    public AudioMixer audioMixer;

    Resolution[] resolutions;

    void Start() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currResIdx = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height){
                currResIdx = i;
            }
         }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currResIdx;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex){
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        Screen.SetResolution(1080, 1920, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }
    public void SwitchToSettingsMenu(){
        SettingsUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void SwitchToMainMenu(){
        SettingsUI.SetActive(false);
        ControlsUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void SwitchToControlsMenu(){
        SettingsUI.SetActive(false);
        MainMenuUI.SetActive(false);
        ControlsUI.SetActive(true);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);    
        Debug.Log(QualitySettings.GetQualityLevel()); 
    }

    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void QuitGame(){
        Time.timeScale = 1f;
        Application.Quit();
    }
}
