using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inspectable : MonoBehaviour
{
    public Transform inspectedObject;
    public float rotationSpeed = 100f;
    private Vector3 previousMousePosition;
    // Update is called once per frame

    public void Update()
    {
        //Get mouse clicks
        if(Input.GetMouseButtonDown(0))
        {
            previousMousePosition = Input.mousePosition;
        }

        //Get mouse holds
        if(Input.GetMouseButton(0))
        {
            Vector3 deltaMousePos = Input.mousePosition - previousMousePosition;
            float rotationX = deltaMousePos.y * rotationSpeed * Time.deltaTime;
            float rotationY = -deltaMousePos.x * rotationSpeed * Time.deltaTime;
            
            Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
            inspectedObject.rotation = rotation * inspectedObject.rotation;

            previousMousePosition = Input.mousePosition;
        }


    }
}
