using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorController : MonoBehaviour
{
    private Animator ElevatorDoorAnimator;

    void Start()
    {
        // Get the Animator component from the child (the elevator door)
        ElevatorDoorAnimator = GetComponentInChildren<Animator>(); 
        
        // Log the name of the GameObject the script is attached to
        Debug.Log("Elevator Controller is attached to: " + gameObject.name);

        // If the animator is found, log the name of the elevator door object
        if (ElevatorDoorAnimator != null)
        {
            Debug.Log("Elevator Door Animator found on: " + ElevatorDoorAnimator.gameObject.name);
        }
        else
        {
            Debug.Log("No Elevator Door Animator found.");
        }
    }

    // Method to open the elevator door
    public void OpenElevatorDoor()
    {
        if (ElevatorDoorAnimator != null)
        {
            ElevatorDoorAnimator.SetTrigger("OpenDoor"); // Trigger door animation
        }
    }

    // Method to transition to the next scene (when player steps in)
    public void TransitionToNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // Load the scene by name
    }
}