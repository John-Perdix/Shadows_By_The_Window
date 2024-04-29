using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public Transform cameraOrientation;

    // Update is called once per frame
    void Update()
    {
        // Get the rotation of the camera's orientation
        Quaternion targetRotation = Quaternion.Euler(0, cameraOrientation.eulerAngles.y, 0);

        // Set the character's rotation to match the camera's rotation
        transform.rotation = targetRotation;
    }
}
