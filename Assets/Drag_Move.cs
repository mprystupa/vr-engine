using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Drag_Move : MonoBehaviour
{

    float distance;
    private Vector3 offset;

    void Start()
    {
        distance = transform.parent.GetComponent<parentScript>().mainCamera
                       .GetComponent<Transform>().position.x;
    }

    void OnMouseDrag()
    {
        offset = transform.GetComponent<Renderer>().bounds.center - transform.position;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition - offset;
    }
}
