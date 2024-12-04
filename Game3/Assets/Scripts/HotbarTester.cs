using UnityEngine;

public class HotbarTester : MonoBehaviour
{
    public HotbarManager hotbarManager; // Reference to your HotbarManager
    public Item testItem;              // A test item to add to the hotbar

    void Update()
    {
        // Add the test item to the hotbar when "1" is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1)) // "1" key
        {
            Debug.Log("Adding test item to the hotbar...");
            hotbarManager.AddItemToHotbar(testItem);
        }
        // Remove item from specific slots when "2", "3", "4", etc., are pressed
        if (Input.GetKeyDown(KeyCode.Alpha2)) // "2" key
        {
            Debug.Log("Removing item from slot 0...");
            hotbarManager.RemoveItemFromHotbar(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) // "3" key
        {
            Debug.Log("Removing item from slot 1...");
            hotbarManager.RemoveItemFromHotbar(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) // "4" key
        {
            Debug.Log("Removing item from slot 2...");
            hotbarManager.RemoveItemFromHotbar(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) // "5" key
        {
            Debug.Log("Removing item from slot 3...");
            hotbarManager.RemoveItemFromHotbar(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) // "6" key
        {
            Debug.Log("Removing item from slot 4...");
            hotbarManager.RemoveItemFromHotbar(4);
        }
    }
}