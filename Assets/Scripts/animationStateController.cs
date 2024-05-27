using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isVaultingHash;
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isVaultingHash = Animator.StringToHash("isVaulting");
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isVaulting = animator.GetBool(isVaultingHash);
        bool forwardPress = Input.GetKey("w");
        bool leftPress = Input.GetKey("a");
        bool rightPress = Input.GetKey("d");
        bool backPress = Input.GetKey("s");

        //if player presses w key
        if (!isWalking && (forwardPress || leftPress || rightPress || backPress))
        {
            animator.SetBool(isWalkingHash, true);
        }

        //if player is not pressing w key
        if (isWalking && !forwardPress && !leftPress && !rightPress && !backPress)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // Vault animation
        /* if (playerMovement.IsVaulting)
        {
            animator.SetBool(isVaultingHash, true);
            Debug.Log("Starting vault animation");
        }
        else
        {
            animator.SetBool(isVaultingHash, false);
            Debug.Log("Ending vault animation");
        } */
    }
}
