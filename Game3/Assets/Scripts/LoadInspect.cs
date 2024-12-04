using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LoadInspect : MonoBehaviour
{
    public Animator transition;
    public Camera inspectCam;

    public float transitionTime = 1f;

    [SerializeField]
    public string inspectableName;

    public void LoadLevel(string inspectableName)
    {
        Debug.Log("Tried Loading: InspectScene"+inspectableName);
        SceneManager.LoadScene("InspectScene"+inspectableName, LoadSceneMode.Additive);
    }

    public void SwitchToLevel(string inspectableName)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("InspectScene"+inspectableName));
        Debug.Log("Tried Switching to:"+SceneManager.GetActiveScene().name);
    }
}
