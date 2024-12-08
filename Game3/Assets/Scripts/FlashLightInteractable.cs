using UnityEngine;

public class FlashlightInteractable : MonoBehaviour
{
    public Item flashlightItem; // Reference to the flashlight's item for the inventory system
    private bool isPickedUp = false; // Flag to track if the flashlight is already picked up

    private HotbarManager hotbarManager; // Reference to HotbarManager

    private void Start()
    {
        // Find the HotbarManager in the scene
        hotbarManager = FindObjectOfType<HotbarManager>();
    }

    // Method to handle the interaction with the flashlight
    public void Interact()
    {
        if (isPickedUp)
        {
            Debug.Log("Flashlight is already picked up.");
            return; // Do nothing if the flashlight has already been picked up
        }

        // Add the flashlight to the hotbar
        if (hotbarManager != null)
        {
            hotbarManager.AddItemToHotbar(flashlightItem); // Add the flashlight item to the hotbar
        }
        
        // Optionally disable the flashlight object in the scene (make it invisible or inactive)
        gameObject.SetActive(false);

        isPickedUp = true; // Set the flag so the flashlight can't be picked up again
        Debug.Log("Flashlight picked up and added to hotbar.");
    }
}