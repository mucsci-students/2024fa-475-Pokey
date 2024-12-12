using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorInteractable : MonoBehaviour
{
    [Header("Scene Settings")]
    public string targetScene; // Name of the scene to load when the elevator button is pressed
public GameObject flashlight;
    public void Interact()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            if (flashlight != null && flashlight.activeSelf) {
                flashlight.SetActive(false);
            }
            Debug.Log($"Changing scene to {targetScene}...");
            SceneManager.LoadScene(targetScene);
        }
        else
        {
            Debug.LogError("Target scene name is not set!");
        }
    }
}