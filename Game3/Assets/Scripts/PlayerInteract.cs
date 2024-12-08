using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class PlayerInteract : MonoBehaviour
{
    public float playerReach = 3f; //distance at which the prompt triggers
    Interactable currentInteractable; //stores current object player is interacting with
    public int inScene = 0;
     [SerializeField] private HotbarManager hotbarManager;  // Reference to HotbarManager
    
    [SerializeField] LoadInspect loadInspect;

    public bool requireInput = false;


    // Update is called once per frame
    void Update()
    {   
        CheckInteraction();
        // if(currentInteractable!=null && Input.GetKeyDown(currentInteractable.keybind) && inScene==0)
        // {   
        //     inScene = 1;

        //     if (currentInteractable!=null)
        //     {
        //     FPSController movement = GetComponent<FPSController>();
        //     movement.enabled = false;
        //         loadInspect.inspectableName = currentInteractable.interactableName;
        //         loadInspect.AddInspectScene(loadInspect.inspectableName);
        //     }

        // }
        // else{
        //     FPSController movement = GetComponent<FPSController>();
        //     movement.enabled = true;
        // }
        if (currentInteractable != null && Input.GetKeyDown(currentInteractable.keybind))
    {
        // Perform the interaction action
        currentInteractable.Interact();

        // Check if the interactable is the flashlight
        if (currentInteractable.gameObject.CompareTag("Interactable"))
        {
            Flashlight flashlight = currentInteractable.GetComponent<Flashlight>();
            if (flashlight != null) // If it has the Flashlight script attached
            {
                Item flashlightItem = currentInteractable.GetComponent<Item>();  // Get the Item component of the flashlight
                if (flashlightItem != null)
                {
                    hotbarManager.AddItemToHotbar(flashlightItem);  // Add the flashlight to the inventory
                    Debug.Log("Flashlight picked up!");
                }
            }
        }
    }

    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();
                if (currentInteractable != null && currentInteractable != newInteractable)
                {
                    currentInteractable.DisableOutline();
                }
                if(newInteractable.enabled)
                {
                    requireInput = true;
                    EnableCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
            else //object in view but not interactable
            {
                DisableCurrentInteractable();
            }
        }
        else //no object in view
        {
            DisableCurrentInteractable();
        }
    }

    void EnableCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        UIManager.instance.EnableInteractPrompt(currentInteractable.keybind, currentInteractable.actionTaken, currentInteractable.interactableName);
    }

    void DisableCurrentInteractable()
    {
        UIManager.instance.DisableInteractPrompt();
        if(currentInteractable!=null)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
