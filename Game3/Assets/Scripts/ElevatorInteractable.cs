using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorInteractable : MonoBehaviour
{
    [Header("Scene Settings")]
    public string targetScene; // Name of the scene to load when the elevator button is pressed

    public void Interact()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            Debug.Log($"Changing scene to {targetScene}...");
            SceneManager.LoadScene(targetScene);
        }
        else
        {
            Debug.LogError("Target scene name is not set!");
        }
    }
}