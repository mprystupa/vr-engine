using UnityEngine;
using System.Collections;

public class Camera_Move : MonoBehaviour
{


    float rotSpeed = 20;

    void OnMouseDrag()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.up, -rotX);
            transform.RotateAround(Vector3.right, rotY);
        }
    }
    
}
