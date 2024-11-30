using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerInteract : MonoBehaviour
{
    public float playerReach = 3f; //distance at which the prompt triggers
    Interactable currentInteractable; //stores current object player is interacting with
    //public Canvas promptCanvas;
    //[SerializeField] LoadInspect enableInspectScene;


    // Update is called once per frame
    void Update()
    {   
        CheckInteraction();
        if(currentInteractable!=null && Input.GetKeyDown(currentInteractable.keybind))
        {   
            

            //currentInteractable.Interact();
            if (currentInteractable!=null)
            {
                //enableInspectScene.inspectableName = currentInteractable.interactableName;
                //enableInspectScene.enabled = true;//toggle inspect "scene"

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    //enableInspectScene.enabled = false;
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
