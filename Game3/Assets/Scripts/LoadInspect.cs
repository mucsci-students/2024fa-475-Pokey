using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LoadInspect : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    [SerializeField]
    public string inspectableName;

    void Awake()
    {
        StartCoroutine(LoadLevel(inspectableName));
    }

    IEnumerator LoadLevel(string inspectableName)
    {
        GameObject originalGameObject = GameObject.Find("Player");

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadSceneAsync(inspectableName, LoadSceneMode.Additive);
        
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(inspectableName));
    }
}
