using UnityEngine;

public class DoorAction : MonoBehaviour
{
    public string requiredKeyName; // Leave empty for doors that don't require a key
    public Animator doorAnimator;  // Animator for the door
    public GameObject doorObject;  // Door GameObject to manipulate (optional)
    public Keypad keypad;  

    public void OpenDoor()
    {
        // Get the player's inventory
        HotbarManager hotbar = FindObjectOfType<HotbarManager>();

        // Check if the door requires a key
        if (!string.IsNullOrEmpty(requiredKeyName))
        {
            if (hotbar != null && hotbar.HasItem(requiredKeyName))
            {
                Debug.Log("Door opened!");
                Open();
                hotbar.RemoveItemFromHotbarByName(requiredKeyName);
            }
            else
            {
                Debug.Log("You need the key to open this door.");
            }
        } else if (keypad != null) {
            if (keypad.isCorrect) {
                Debug.Log("Door opened!");
                Open();
            }
            else {
                Debug.Log("You need the right passcode");
            }
        }
        else
        {
            // No key required
            Debug.Log("Door opened without a key!");
            Open();
        }
    }

    private void Open()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
        else if (doorObject != null)
        {
            doorObject.SetActive(false); // Optional: Hide or disable the door
        }
    }
}