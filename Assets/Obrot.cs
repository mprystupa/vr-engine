using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obrot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    int rotSpeed = 20;

    void OnMouseDrag()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            this.transform.RotateAroundLocal(Vector3.up, -rotX);
            this.transform.RotateAroundLocal(Vector3.right, rotY);
        }
    }
    }
