using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource footstepsSounds;

    float horizontalInput;
    float verticalInput;
    bool isMoving;

    void Start()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void Update()
    {
        isMoving = horizontalInput != 0 || verticalInput != 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footstepsSounds.enabled = true;
        }
        else
        {
            footstepsSounds.enabled = false;
        }

        if (isMoving)
        {
            footstepsSounds.enabled = true;
        }
        else
        {
            footstepsSounds.enabled = false;
        }
    }
}
