using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float normalSpeed;
    public float moveSprint;
    private float moveSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    private bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode shiftKey = KeyCode.LeftShift;

    [Header("Teleporting")]
    public LayerMask vaultableLayer;
    public float vaultDistance = 0.1f;
    private bool canTeleport;

    public Transform orientation;
    public Transform cameraTransform; // Reference to the camera transform

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    private Vector3 teleportEndPos;

    private Rigidbody rb;

    public PressKeyOpenDoor pressKeyOpenDoor;

    private void Start()
    {
        readyToJump = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Debug.Log("PlayerMovement script started");
        moveSpeed = normalSpeed;
    }

    private void Update()
    {
        // Teleport check with Debug Ray
        Vector3 rayStart = transform.position + new Vector3(0, 0.5f, 0); // Adjust if needed
        Vector3 rayDirection = cameraTransform.forward;
        Debug.DrawRay(rayStart, rayDirection * vaultDistance, Color.red);
        RaycastHit hit;
        canTeleport = Physics.Raycast(rayStart, rayDirection, out hit, vaultDistance, vaultableLayer);

        //Debug.Log("Can Teleport: " + canTeleport);
        if (canTeleport)
        {
            // Debug.Log("Hit object: " + hit.collider.name);
        }

        MyInput();
        SpeedControl();

        // Handle drag
        rb.drag = groundDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // When to jump or teleport
        if (Input.GetKeyDown(jumpKey) && readyToJump)
        {
            //Debug.Log("Space key pressed");

            if (canTeleport)
            {
                //Debug.Log("Starting Teleport");
                Teleport();
            }
            else
            {
                //Debug.Log("Jumping");
                readyToJump = false;
                Jump();
                Invoke(nameof(ResetJump), jumpCooldown);
            }
        }

        if (Input.GetKeyDown(shiftKey))
        {
            moveSpeed = moveSprint;
        }
        else if (Input.GetKeyUp(shiftKey))
        {
            moveSpeed = normalSpeed;
        }

    }

    private void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // On ground 
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }

    private void SpeedControl()
    {
        Vector3 flatVal = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Limit velocity if needed
        if (flatVal.magnitude > moveSpeed)
        {
            Vector3 limitedVal = flatVal.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVal.x, rb.velocity.y, limitedVal.z);
        }
    }

    private void Jump()
    {
        // Reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void Teleport()
    {
        pressKeyOpenDoor = FindObjectOfType<PressKeyOpenDoor>();
        bool closed = pressKeyOpenDoor.windowClosed;

        if (canTeleport && !closed)
        {
            // Calculate the teleport end position
            teleportEndPos = transform.position + cameraTransform.forward * vaultDistance;

            // Log the teleport action
            Debug.Log("Teleporting to: " + teleportEndPos);

            // Teleport the player
            rb.MovePosition(teleportEndPos);

            // Optional: Reset the player's velocity to prevent unwanted movement
            rb.velocity = Vector3.zero;

            // Mark as ready to jump again immediately
            readyToJump = true;

            Debug.Log("Teleport successful");
        }
        else
        {
            Debug.Log("Teleport failed: No vaultable object in range");
        }
    }
}
