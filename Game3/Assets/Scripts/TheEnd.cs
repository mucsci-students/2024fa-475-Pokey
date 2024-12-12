using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    void Start() {
         Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void mainMenu() {
         SceneManager.LoadScene("MainMenu"); 
    }
}
