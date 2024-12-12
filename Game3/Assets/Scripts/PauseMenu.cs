using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // references the pause menu UI
    public GameObject settingsMenuUI; // references the settings menu UI

    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;

    private bool isPaused = false;

    void Start()
    {
         // Initialize sliders with current volume values from SoundManager
        musicVolumeSlider.value = SoundManager.Instance.MusicVolume;
        sfxVolumeSlider.value = SoundManager.Instance.SFXVolume;
    }

      public void OnMusicVolumeChanged()
    {
        SoundManager.Instance.ChangeMusicVolume();
    }

    public void OnSFXVolumeChanged()
    {
        SoundManager.Instance.ChangeSFXVolume();
    }
    
    void Update()
    {
        // checks if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused && !settingsMenuUI.activeSelf) {
                ResumeGame();
            }
            else if (!isPaused) {
                PauseGame();
            }
        }
    }

    // shows the pause menu
    public void PauseGame() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // resumes the game if the player presses esc when paused or clicks the resume button
    public void ResumeGame() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // shows settings 
     public void OpenSettings()
    {
        Debug.Log("Opening settings");
        pauseMenuUI.SetActive(false); // Hide the pause menu
        settingsMenuUI.SetActive(true); // Show the options menu
    }

    // closes settings
    public void CloseSettings()
    {
        settingsMenuUI.SetActive(false); // Hide the options menu
        pauseMenuUI.SetActive(true); // Show the pause menu
    }

    // goes to the main menu if the button is pressed
    public void ExitGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void theEnd() {
        SceneManager.LoadScene("End");
    }
}
