using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HotbarManager : MonoBehaviour
{
    public Image[] slotImages; // UI images representing each hotbar slot
    public Sprite defaultSlotSprite; // Sprite for empty slots
    private Item[] hotbarItems; // Array to store the items in the hotbar

    public Item startingKey; // The key item the player starts with (only in the first level)

    private void Start()
    {
        Debug.Log($"SlotImages array length: {slotImages.Length}");
        hotbarItems = new Item[slotImages.Length]; // Initialize the hotbar item array
        Debug.Log($"HotbarItems array length: {hotbarItems.Length}");

         // Check if the current scene is the first level
        if (IsFirstLevel() && startingKey != null)
        {
            AddItemToHotbar(startingKey);
        }

        UpdateHotbarUI();
    }

    public void AddItemToHotbar(Item newItem)
    {
        // Find the first empty slot
        for (int i = 0; i < hotbarItems.Length; i++)
        {
            if (hotbarItems[i] == null)
            {
                hotbarItems[i] = newItem;
                UpdateHotbarUI();
                return;
            }
        }

        // Optional: Handle full hotbar
        Debug.Log("Hotbar is full!");
    }

    public void RemoveItemFromHotbar(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < hotbarItems.Length)
        {
            hotbarItems[slotIndex] = null;
            UpdateHotbarUI();
        }
    }

    private void UpdateHotbarUI()
    {
        // Update the UI for each slot
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (hotbarItems[i] != null)
            {
                slotImages[i].sprite = hotbarItems[i].itemSprite;
            }
            else
            {
                Debug.Log("Adding default");
                slotImages[i].sprite = defaultSlotSprite; // Set to default empty slot sprite
            }
        }
    }
     private bool IsFirstLevel()
    {
        // Check by scene name 
        string sceneName = SceneManager.GetActiveScene().name;

        return sceneName == "First Level";
    }
}