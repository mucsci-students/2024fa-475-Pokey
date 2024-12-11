using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HotbarManager : MonoBehaviour
{
    public Image[] slotImages; // UI images representing each hotbar slot
    public Sprite defaultSlotSprite; // Sprite for empty slots
    private static Item[] staticHotbarItems; // Static array to store hotbar items across scenes
    public GameObject flashlightObject;

    public Item startingKey; // The key item the player starts with (only in the first level)

    private static HotbarManager instance;

    // Ensures only one instance of HotbarManager persists across scenes
    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist this instance across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        
        // Initialize the static hotbar items if not already initialized
        if (staticHotbarItems == null)
        {
            staticHotbarItems = new Item[slotImages.Length];
        }
    }

    private void Start()
    {
         // Ensure the flashlightObject is correctly assigned
    if (flashlightObject == null)
    {
        flashlightObject = GameObject.Find("Flashlight"); // Assuming the flashlight object is named "Flashlight"
    }

    // Ensure the flashlight object is persisted across scenes
    DontDestroyOnLoad(flashlightObject);
        // Initialize hotbarItems to the static array so they persist across scenes
        // Here, we use staticHotbarItems instead of hotbarItems
        var hotbarItems = staticHotbarItems;

        // Check if this is the first level and if the startingKey exists
        if (IsFirstLevel() && startingKey != null)
        {
            AddItemToHotbar(startingKey); // Add the starting key to the hotbar
        }

        // Update the hotbar UI to reflect the current items
        UpdateHotbarUI();
    }

    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event to handle UI updates when scenes change
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from sceneLoaded to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Make sure to update the hotbar UI after the scene loads
        UpdateHotbarUI();
    }

    // Method to add an item to the hotbar
    public void AddItemToHotbar(Item newItem)
    {
         // Check if the flashlight object is not already set to persist
    if (newItem.itemName == "Flashlight" && flashlightObject != null)
    {
        Debug.Log("Flashlight won't destroy on load");
        DontDestroyOnLoad(flashlightObject); // Make the flashlight persist across scenes
    }
        // Here, we use staticHotbarItems instead of hotbarItems
        for (int i = 0; i < staticHotbarItems.Length; i++)
        {
            if (staticHotbarItems[i] == null) // Find the first empty slot
            {
                staticHotbarItems[i] = newItem;
                UpdateHotbarUI(); // Update the UI to reflect the changes
                return;
            }
        }

        // Optionally handle full hotbar (e.g., don't add new items)
        Debug.Log("Hotbar is full!");
    }

    // Method to remove an item from the hotbar by its index
    public void RemoveItemFromHotbar(int slotIndex)
    {
        
        if (slotIndex >= 0 && slotIndex < staticHotbarItems.Length)
        {
            staticHotbarItems[slotIndex] = null;
            UpdateHotbarUI();
        }
    }

    // Method to update the hotbar UI
    private void UpdateHotbarUI()
    {
        
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (staticHotbarItems[i] != null)
            {
                 Debug.Log($"Slot {i} contains {staticHotbarItems[i].itemName}");
                slotImages[i].sprite = staticHotbarItems[i].itemSprite;
            }
            else
            {
                slotImages[i].sprite = defaultSlotSprite; // Default sprite for empty slots
            }
        }
    }

    // Helper method to check if it's the first level 
    private bool IsFirstLevel()
    {
        return SceneManager.GetActiveScene().name == "First Level";
    }
    
    // Method to check if an item is in the hotbar by name
    public bool HasItem(string itemName)
    {
        // Here, we use staticHotbarItems instead of hotbarItems
        foreach (Item item in staticHotbarItems)
        {
            if (item != null && item.itemName == itemName)
            {
                return true;
            }
        }
        return false;
    }

    // Method to remove an item by its name
    public void RemoveItemFromHotbarByName(string itemName)
    {
        // Here, we use staticHotbarItems instead of hotbarItems
        for (int i = 0; i < staticHotbarItems.Length; i++)
        {
            if (staticHotbarItems[i] != null && staticHotbarItems[i].itemName == itemName)
            {
                staticHotbarItems[i] = null;
                UpdateHotbarUI();
                return;
            }
        }
    }
}
