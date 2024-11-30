using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] 
    TMP_Text interactionPrompt;

    private void Awake()
    {
        instance = this;
    }


    public void EnableInteractPrompt(KeyCode keybind, string actionTaken)
    {
        interactionPrompt.text = "(" + keybind + ") " + actionTaken;
        interactionPrompt.gameObject.SetActive(true);
    }

    public void EnableInteractPrompt(KeyCode keybind, string actionTaken, string objectName)
    {
        interactionPrompt.text = "(" + keybind + ") " + actionTaken + " " + objectName;
        interactionPrompt.gameObject.SetActive(true);
    }

    public void DisableInteractPrompt()
    {
        interactionPrompt.gameObject.SetActive(false);
    }
}
