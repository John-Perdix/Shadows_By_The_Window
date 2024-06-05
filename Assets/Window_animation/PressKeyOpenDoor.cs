using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject InstructionOpen;
    public GameObject InstructionClose;
    public GameObject InstructionGrabKey;
    public GameObject AnimeObject1;
    public GameObject AnimeObject2;
    public GameObject ThisTrigger;
    public AudioSource DoorOpenSound;
    public bool Action = false;
    public bool windowClosed = true;
    public Animator animator;
   //public GameObject[] prefabsToInstantiate; // Array of prefabs to cycle through
    //private GameObject currentPrefabInstance; // Reference to the currently instantiated prefab
    //private int currentPrefabIndex = 0;
    PickUpScript pickupScript;


    void Start()
    {
        InstructionOpen.SetActive(false);
        InstructionClose.SetActive(false);
        InstructionGrabKey.SetActive(false);
        pickupScript = GameObject.Find("PlayerCam").GetComponent<PickUpScript>();
    }

    void OnTriggerEnter(Collider collision)
    {
        bool hasKey = pickupScript.heldObj != null && pickupScript.heldObj.CompareTag("key");
        if (collision.transform.CompareTag("Player"))
        {
            if (hasKey)
            {
                InstructionOpen.SetActive(true);
                Action = true;
                print("Colliding");
                print(Action);
            }
            else
            {
                InstructionGrabKey.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        InstructionOpen.SetActive(false);
        InstructionClose.SetActive(false);
        InstructionGrabKey.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                if (pickupScript.heldObj.CompareTag("key"))
                {
                    CheckAnimation();
                    if (!isAnimating)
                    {
                        if (windowClosed == true)
                        {
                            InstructionOpen.SetActive(false);
                            InstructionClose.SetActive(true);
                            AnimeObject1.GetComponent<Animator>().Play("open-window");
                            AnimeObject2.GetComponent<Animator>().Play("open-window-dir");
                            //ThisTrigger.SetActive(false);
                            DoorOpenSound.Play();
                            //Action = false;
                            windowClosed = false;

                            //Manage adding new objects
                            // Delete the previous prefab instance if it exists
                            /*if (currentPrefabInstance != null)
                            {
                                Destroy(currentPrefabInstance);
                            }
                            // Instantiate the new prefab
                            currentPrefabInstance = Instantiate(prefabsToInstantiate[currentPrefabIndex], transform.position, transform.rotation);
                            // Move to the next prefab in the array
                            currentPrefabIndex = (currentPrefabIndex + 1) % prefabsToInstantiate.Length;*/
                        }
                        else
                        {
                            InstructionOpen.SetActive(true);
                            InstructionClose.SetActive(false);
                            AnimeObject1.GetComponent<Animator>().Play("close-window");
                            AnimeObject2.GetComponent<Animator>().Play("close-window-dir");
                            //ThisTrigger.SetActive(false);
                            DoorOpenSound.Play();
                            windowClosed = true;
                            //Action = false;
                        }
                    }
                }
            }
        }

    }

    bool isAnimating = false;
    void CheckAnimation()
    {
        // Get the current state information of the animator
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

        // Check if the animation is playing
        if ((currentState.IsName("open-window") || currentState.IsName("close-window")) && currentState.normalizedTime < 1.0f)
        {
            // Set the flag to indicate that the animation is currently playing
            isAnimating = true;
        }
        else
        {
            // Reset the flag if the animation has finished playing
            isAnimating = false;
        }
    }
}