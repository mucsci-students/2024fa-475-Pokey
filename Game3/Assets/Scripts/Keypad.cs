using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject hud;
    public GameObject inv;


    public GameObject animateOB;
    public Animator ANI;


    public Text textOB;
    public string answer = "4372";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    public bool animate;

    public bool isCorrect;


    void Start()
    {
        keypadOB.SetActive(false);

    }


    public void Number(int number)
    {
        textOB.text += number.ToString();
        button.Play();
    }

    public void Execute()
    {
        if (textOB.text == answer)
        {
            //correct.Play();
            textOB.text = "Right";
            isCorrect = true;

        }
        else
        {
            //wrong.Play();
            textOB.text = "Wrong";
            isCorrect = false;
        }


    }

    public void Clear()
    {
        {
            textOB.text = "";
            button.Play();
        }
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        //inv.SetActive(true);
        hud.SetActive(true);
        Cursor.visible = false;
        player.GetComponent<FPSController>().enabled = true;
    }

    public void Update()
    {
        if (textOB.text == "Right" && animate)
        {
            ANI.SetBool("animate", true);
            Debug.Log("its open");
        }


        if(keypadOB.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            player.GetComponent<FPSController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
    public void ShowKeypad()
{
    player.GetComponent<FPSController>().enabled = false;
    keypadOB.SetActive(true);
    Cursor.lockState = CursorLockMode.None;
Cursor.visible = true;
}


}
