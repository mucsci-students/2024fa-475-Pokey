using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class PlayerInteract : MonoBehaviour
{
    public float playerReach = 3f; //distance at which the prompt triggers
    Interactable currentInteractable; //stores current object player is interacting with
    
    [SerializeField] LoadInspect loadInspect;

    public bool requireInput = false;


    // Update is called once per frame
    void Update()
    {   
        CheckInteraction();
        if(currentInteractable!=null && Input.GetKeyDown(currentInteractable.keybind))
        {   
            if(requireInput)
            {
                FPSController movement = GetComponent<FPSController>();
                movement.enabled = false;
            }
            else{
                FPSController movement = GetComponent<FPSController>();
                movement.enabled = false;
            }
            if (currentInteractable!=null)
            {
                loadInspect.inspectableName = currentInteractable.interactableName;
                loadInspect.LoadLevel(loadInspect.inspectableName);
                loadInspect.SwitchToLevel(loadInspect.inspectableName);

                if(Input.GetKeyDown(KeyCode.Alpha2))
                {
                    requireInput = false;
                    loadInspect.enabled = false;
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
