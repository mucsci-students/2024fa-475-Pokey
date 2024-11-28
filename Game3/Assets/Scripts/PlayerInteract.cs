using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerInteract : MonoBehaviour
{
    FPSController movement;
    public float playerReach = 3f; //distance at which the prompt triggers
    Interactable currentInteractable; //stores current object player is interacting with
    Inspectable currentInspectable; //ref the inspectable script if need be for this object
    public Canvas promptCanvas;
    [SerializeField] TMP_Text promptText;
    [SerializeField] Canvas inspectBackgroundCanvas;


    // Update is called once per frame
    void Update()
    {   
        CheckInteraction();
        if(currentInteractable!=null && Input.GetKeyDown(KeyCode.Tab))
        {   
            inspectBackgroundCanvas.enabled = true;

            movement = GetComponent<FPSController>();
            movement.enabled = !movement.enabled;

            currentInteractable.Interact();
            if (currentInspectable!=null)
            {
                currentInspectable.enabled = !currentInspectable.enabled; //toggle inspect "scene"
            }

        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            inspectBackgroundCanvas.enabled = false;
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
                Inspectable newInspectable = hit.collider.GetComponent<Inspectable>();
                if (currentInteractable != newInteractable)
                {
                    if (currentInteractable != null)
                    {
                        currentInteractable.DisableOutline();
                    }
                    EnableCurrentInteractable(newInteractable, newInspectable);
                }
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }

    void EnableCurrentInteractable(Interactable newInteractable, Inspectable newInspectable)
    {
        currentInteractable = newInteractable;
        currentInspectable = newInspectable;
        currentInteractable.EnableOutline();
        promptCanvas.enabled = true;
    }

    void DisableCurrentInteractable()
    {
        if(currentInteractable!=null)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
            currentInspectable = null;
            promptCanvas.enabled = false;
        }
    }
}
