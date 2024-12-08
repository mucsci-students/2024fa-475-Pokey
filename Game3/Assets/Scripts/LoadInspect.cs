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
    
    public string ogScene;

    public void AddInspectScene(string inspectableName)
    {
        ogScene = SceneManager.GetActiveScene().name;
        Debug.Log("Tried Loading: InspectScene"+inspectableName);
        SceneManager.LoadSceneAsync("InspectScene"+inspectableName, LoadSceneMode.Additive);
        SwitchToInspect(inspectableName);
    }

    public void SwitchToInspect(string inspectableName)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("InspectScene"+inspectableName));
        Debug.Log("Tried Switching to:"+SceneManager.GetActiveScene().name);
    }

}
