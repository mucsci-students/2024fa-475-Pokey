using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public string prompt;
    public UnityEvent onInteraction;
    private Inspectable inspectable;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        inspectable = GetComponent<Inspectable>();
        if(outline!=null)
            {DisableOutline();}
    }

    public void Interact()
    {
        onInteraction.Invoke();
        if(inspectable!=null)
        {
            inspectable.enabled = true;
        }
    }

    public void DisableOutline()
    {
        if(outline!=null)
            outline.enabled = false;
    }

    public void EnableOutline()
    {
        if(outline!=null)
            outline.enabled = true;
    }
}
