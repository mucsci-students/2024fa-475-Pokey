using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class RadioPuzzle : MonoBehaviour
{
    public float minFrequency = 88.0f;
    public float maxFrequency = 108.0f;
    public float tinyStep = 0.1f; // Step size for tuning
    public float bigStep = 1f; // Step size for tuning
    public float targetFrequency = 105.5f; // Correct frequency
    public float tolerance = 0.0f; // Originally a var to allow slight inaccuracy

    private float currentFrequency = 88.0f;
    public TextMeshPro currentFText;
    public float CurrentF{
        get{return currentFrequency;}
        set{
            currentFrequency = value;
            currentFText.SetText("Playing: " + Math.Round(currentFrequency, 3) + "MHz");
        }
    }

public DoorAction door;
    public GameObject doorToUnlock; // Door that unlocks
    public AudioSource[] radioTunes; // Plays audio when tuned
    
    [SerializeField] 
    float[] solutions;

    [SerializeField]
    KeyCode powerButton = KeyCode.Space;


    [SerializeField]
    KeyCode finelowerFrequencyButton = KeyCode.LeftArrow;

    [SerializeField]
    KeyCode fineraiseFrequencyButton = KeyCode.RightArrow;
        
    [SerializeField]
    KeyCode lowerFrequencyButton = KeyCode.DownArrow;

    [SerializeField]
    KeyCode raiseFrequencyButton = KeyCode.UpArrow;

    public void Update()
    {
        // Rotate dial and change frequency
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.UnloadSceneAsync("InspectSceneRadio");
            FPSController movement = GetComponent<FPSController>();
            movement.enabled = true;
            PlayerInteract interact = GetComponent<PlayerInteract>();
            interact.inScene = 0;
        }
        if (Input.GetKeyDown(fineraiseFrequencyButton)) AdjustFrequency(tinyStep);
        if (Input.GetKeyDown(finelowerFrequencyButton)) AdjustFrequency(-tinyStep);
        if (Input.GetKeyDown(raiseFrequencyButton)) AdjustFrequency(bigStep);
        if (Input.GetKeyDown(lowerFrequencyButton)) AdjustFrequency(-bigStep);
        CurrentF = currentFrequency;

        // Check if the player has tuned to the correct frequency
        CheckFrequency();
    }

    void AdjustFrequency(float step)
    {
        currentFrequency = Mathf.Clamp(currentFrequency + step, minFrequency, maxFrequency);
        UpdateRadioAudio();
    }

    void UpdateRadioAudio()
    {
        // simulate static or correct audio based on frequency
        if (Mathf.Abs(currentFrequency - targetFrequency) < tolerance)
        {
            Silence();
            radioTunes[1].Play();
            
        }
        else
        {
            Silence();
            radioTunes[0].Play(); //we can store static in the first index
        }
    }

    void CheckFrequency()
    {
        //check for delay here
if (currentFrequency == targetFrequency) {
    UnlockDoor();
}
        if (Mathf.Abs(currentFrequency - targetFrequency) < tolerance)
        {
            UnlockDoor();
        }
    }

    void UnlockDoor()
    {
        if (doorToUnlock != null)
        {
            doorToUnlock.SetActive(false); // Simulate unlocking
            door.Open();
            Debug.Log("Door unlocked!");
        }
    }

    public void Silence()
    {
        foreach(AudioSource audio in radioTunes){
            if(audio.isPlaying)
            {
                audio.Stop();
            }
        }
    }
}