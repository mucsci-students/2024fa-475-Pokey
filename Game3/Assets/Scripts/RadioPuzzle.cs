using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RadioPuzzle : MonoBehaviour
{
    public float minFrequency = 88.0f;
    public float maxFrequency = 108.0f;
    public float tinyStep = 0.1f; // Step size for tuning
    public float bigStep = 1f; // Step size for tuning
    public float targetFrequency = 95.3f; // Correct frequency
    public float tolerance = 0.2f; // Allow slight inaccuracy

    private float currentFrequency = 88.0f;

    public TextMeshPro currentFText;
    public float CurrentF{
        get{return currentFrequency;}
        set{
            currentFrequency = value;
            currentFText.SetText("Playing: " + Math.Round(currentFrequency, 3) + "MHz");
        }
    }

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
            if(currentFrequency == solutions[0])
                radioTunes[1].Play();
            else if(currentFrequency == solutions[1])
                radioTunes[2].Play();
            else if(currentFrequency == solutions[2])
                radioTunes[3].Play();
            
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