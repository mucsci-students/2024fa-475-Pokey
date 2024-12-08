using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public UnityEvent onInteraction;

    [SerializeField] 
    public KeyCode keybind;

    [SerializeField]
    public string actionTaken;

    [SerializeField]
    public string interactableName;


    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableOutline()
    {
        Debug.Log($"Disabling outline on {gameObject.name}");
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }
}
