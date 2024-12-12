using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// used in the settings when the player controls the volume
public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; private set; }

    [SerializeField] Slider musicVolumeSlider; // Slider for music volume
    [SerializeField] Slider sfxVolumeSlider;   // Slider for sound effects volume
    [SerializeField] AudioSource musicAudioSource;  // Music AudioSource
    [SerializeField] AudioSource sfxAudioSource;    // Sound effects AudioSource

     // Add public properties for the audio sources
    public float MusicVolume => musicAudioSource.volume;
    public float SFXVolume => sfxAudioSource.volume;


void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes

     // Ensure AudioSources are assigned
    if (musicAudioSource == null)
        musicAudioSource = gameObject.AddComponent<AudioSource>(); // Adds a default AudioSource if missing

    if (sfxAudioSource == null)
        sfxAudioSource = gameObject.AddComponent<AudioSource>();
    }
    void Start()
    {
        // Load stored volume preferences if they exist, otherwise set to default
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            PlayerPrefs.SetFloat("sfxVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Adjust the music volume and save it
    public void ChangeMusicVolume()
    {
        musicAudioSource.volume = musicVolumeSlider.value;
        Save();
    }

    // Adjust the sound effects volume and save it
    public void ChangeSFXVolume()
    {
        sfxAudioSource.volume = sfxVolumeSlider.value;
        Save();
    }

    // Load volume preferences from PlayerPrefs
    private void Load()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        // Set the audio sources' volume to the loaded values
        musicAudioSource.volume = musicVolumeSlider.value;
        sfxAudioSource.volume = sfxVolumeSlider.value;
    }

    // Save the current volume settings to PlayerPrefs
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolumeSlider.value);
    }
    public void PlayMusic(AudioClip newMusic)
{
    if (musicAudioSource.clip == newMusic) return; // Avoid restarting the same music
    musicAudioSource.clip = newMusic;
    musicAudioSource.Play();
}
}
