using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update() 
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //Get controller right stick input
        float controllerX = Input.GetAxisRaw("RightStickHorizontal") * sensX * Time.deltaTime;
        float controllerY = Input.GetAxisRaw("RightStickVertical") * sensY * Time.deltaTime;

        //yRotation += mouseX;
        //xRotation -= mouseY;
        yRotation += controllerX;
        xRotation -= controllerY;

        //Impedir que rode mais do que 150º verticalmente
        xRotation = Mathf.Clamp(xRotation, -75f, 75f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation,0);
        
    }
}
