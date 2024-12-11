using UnityEngine;

public class ItemInteractable : MonoBehaviour
{
    public Item item; // Reference to the item for the inventory system
    private bool isPickedUp = false; // Flag to track if the item is already picked up

    private HotbarManager hotbarManager; // Reference to HotbarManager

    private void Start()
    {
        // Find the HotbarManager in the scene
        hotbarManager = FindObjectOfType<HotbarManager>();
    }

    // Method to handle the interaction with the item
    public void Interact()
    {
        if (isPickedUp)
        {
            Debug.Log($"{item.itemName} is already picked up.");
            return; // Do nothing if the item has already been picked up
        }

        // Add the item to the hotbar
        if (hotbarManager != null)
        {
            hotbarManager.AddItemToHotbar(item); // Add the item to the hotbar
        }

        // Optionally disable the item object in the scene (make it invisible or inactive)
        gameObject.SetActive(false);

        isPickedUp = true; // Set the flag so the item can't be picked up again
        Debug.Log($"{item.itemName} picked up and added to hotbar.");
    }
}