using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioPuzzle : MonoBehaviour
{
    public float minFrequency = 88.0f;
    public float maxFrequency = 108.0f;
    public float frequencyStep = 0.1f; // Step size for tuning
    public float targetFrequency = 95.3f; // Correct frequency
    public float tolerance = 0.05f; // Allow slight inaccuracy

    private float currentFrequency = 88.0f;

    public GameObject doorToUnlock; // Door that unlocks
    public AudioSource[] radioTunes; // Plays audio when tuned
    public float[] solutions;

    public void Update()
    {
        // Rotate dial and change frequency
        if (Input.GetKeyDown(KeyCode.RightArrow)) AdjustFrequency(frequencyStep);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) AdjustFrequency(-frequencyStep);

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
            /*
            if(currentFrequency == SOLUTION_ONE)
                radioTunes[1].Play();
            else if(currentFrequency == SOLUTION_TWO)
                radioTunes[2].Play();
            else if(currentFrequency == SOLUTION_THREE)
                radioTunes[3].Play();
            */
            radioTunes[1].Play();
        }
        else
        {
            ShutOff();
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

    public void ShutOff()
    {
        foreach(AudioSource audio in radioTunes){
            if(audio.isPlaying)
            {
                audio.Stop();
            }
        }
    }
}