using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI; // reference the main menu UI
    public GameObject controlsMenuUI; // references the controls menu UI
    public GameObject settingsMenuUI; // references the settings menu UI

     [SerializeField] Slider musicVolumeSlider; // reference to the music volume slider
    [SerializeField] Slider sfxVolumeSlider;   // reference to the SFX volume slider


   void Start()
{
     // Initialize sliders with current volume values from SoundManager
        musicVolumeSlider.value = SoundManager.Instance.MusicVolume;
        sfxVolumeSlider.value = SoundManager.Instance.SFXVolume;
}
   // Load the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("pauseMenuTest"); // replace with the actual scene name
    }

    // Show the controls menu
    public void OpenControls()
    {
        mainMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
    }

    // close the controls menu
    public void CloseControls()
    {
        controlsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    // Show the settings menu
    public void OpenSettings()
    {
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    // close the settings menu
    public void CloseSettings()
    {
        settingsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit(); 
    }
}

