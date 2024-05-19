using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClockTimeSystem : MonoBehaviour
{
    public GameObject InstructionTime;
    public GameObject AnimeObject1;
    public GameObject AnimejanelaEsq;
    public GameObject AnimejanelaDir;
    public GameObject ThisTrigger;
    public AudioSource SoundFX;
    public bool Action = false;
    public Animator animator;
    public GameObject[] prefabsToInstantiate; // Array of prefabs to cycle through
    private GameObject currentPrefabInstance; // Reference to the currently instantiated prefab
    private int currentPrefabIndex = 0;
    public PressKeyOpenDoor pressKeyOpenDoor;


    void Start()
    {
        InstructionTime.SetActive(false);
        currentPrefabInstance = Instantiate(prefabsToInstantiate[currentPrefabIndex]);
        currentPrefabIndex = (currentPrefabIndex + 1) % prefabsToInstantiate.Length;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            InstructionTime.SetActive(true);
            Action = true;
            print("Colliding");
            print(Action);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        InstructionTime.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                        InstructionTime.SetActive(false);
                        AnimeObject1.GetComponent<Animator>().Play("ClockAnime");
                        //ThisTrigger.SetActive(false);
                        SoundFX.Play();
                        //Action = false;

                        //Manage adding new objects
                        // Delete the previous prefab instance if it exists
                        if (currentPrefabInstance != null)
                        {
                            Destroy(currentPrefabInstance);
                        }
                        // Instantiate the new prefab
                        currentPrefabInstance = Instantiate(prefabsToInstantiate[currentPrefabIndex], transform.position, transform.rotation);
                        // Move to the next prefab in the array
                        currentPrefabIndex = (currentPrefabIndex + 1) % prefabsToInstantiate.Length;


                        pressKeyOpenDoor = FindObjectOfType<PressKeyOpenDoor>();
                        bool closed = pressKeyOpenDoor.windowClosed;
                        if(closed == false){
                            AnimejanelaEsq.GetComponent<Animator>().Play("close-window");
                            AnimejanelaDir.GetComponent<Animator>().Play("close-window-dir");
                        }
                //}
                //ORIGINAL CODE
                /*Instruction.SetActive(false);
                AnimeObject1.GetComponent<Animator>().Play("open-window");
                AnimeObject2.GetComponent<Animator>().Play("open-window-dir");
                ThisTrigger.SetActive(false);
                SoundFX.Play();
                Action = false; */
            }
        }

    }

/*
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
    }*/
}