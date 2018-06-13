using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //Obiekt odpowiedzialny za ruch gracza.
    public CharacterController characterControler;
    //Czulość myszki (Sensitivity)
    public float mouseSensitivity = 4.0f;
    // Use this for initialization
    float minFov = 15f;
    float maxFov = 90f;
    public  float zoomSensitivity = 20f;
    void Start()
    {
        characterControler = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        mouse();
        zoom();
    }
    private void mouse()
    {
        //Pobranie wartości ruchu myszki lewo/prawo.
        // jeżeli wartość dodatnia to poruszamy w prawo,
        // jeżeli wartość ujemna to poruszamy w lewo.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float mouseLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseUpDown = Input.GetAxis("Mouse Y") * mouseSensitivity;
            transform.Rotate(0, mouseLeftRight, mouseUpDown);
        }
    }
    private void zoom()
    {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
