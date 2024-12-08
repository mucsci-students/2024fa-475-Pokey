using UnityEngine;

public class DoorAction : MonoBehaviour
{
    public string requiredKeyName; // Name of the key needed to open the door
    public Animator doorAnimator;  // Animator for the door
    public GameObject doorObject;  // Door GameObject to manipulate (optional)

    public void OpenDoor()
    {
        // Get the player's inventory
        HotbarManager hotbar = FindObjectOfType<HotbarManager>();

        if (hotbar != null && hotbar.HasItem(requiredKeyName))
        {
            Debug.Log("Door opened!");
            
            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("Open");
            }
            else if (doorObject != null)
            {
                doorObject.SetActive(false); // Optional: Hide or disable the door
            }

            hotbar.RemoveItemFromHotbarByName(requiredKeyName);
        }
        else
        {
            Debug.Log("You need the key to open this door.");
        }
    }
}