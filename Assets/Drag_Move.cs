using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Drag_Move : MonoBehaviour
{
    public float rotSpeed = 20.0F;
    private float distance;
    private Vector3 offset;
    private Vector3 startingPosition;
    private Boolean isMouseClicked = false;

    void Start()
    {
        distance = (float)Math.Sqrt(Math.Pow(transform.parent.GetComponent<parentScript>().mainCamera
                       .GetComponent<Transform>().position.x, 2) + 
                                    Math.Pow(transform.parent.GetComponent<parentScript>().mainCamera
                                        .GetComponent<Transform>().position.y, 2) + 
                                    Math.Pow(transform.parent.GetComponent<parentScript>().mainCamera
                                        .GetComponent<Transform>().position.z, 2));

        startingPosition = this.transform.GetComponent<move>().startingPosition;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, startingPosition) < 0.5 && isMouseClicked == false) 
            transform.position = startingPosition;
    }

    void OnMouseDrag()
    {
        isMouseClicked = true;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
 
            this.transform.RotateAroundLocal(Vector3.up, -rotX);
            this.transform.RotateAroundLocal(Vector3.right, rotY);
        }
        else
        {
            offset = transform.GetComponent<Renderer>().bounds.center - transform.position;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = objPosition - offset;
        }    
    }

    private void OnMouseUp()
    {
        isMouseClicked = false;
    }
}
