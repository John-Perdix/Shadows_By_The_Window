using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClockTimeSystem : MonoBehaviour
{
    public GameObject InstructionTime;
    public GameObject InstructionGrabBook;
    public GameObject InstructionPickObjects;
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
    PickUpScript pickupScript;
    public ScoreSystem scoreSystem;


    void Start()
    {
        InstructionTime.SetActive(false);
        InstructionGrabBook.SetActive(false);
        InstructionPickObjects.SetActive(false);
        currentPrefabInstance = Instantiate(prefabsToInstantiate[currentPrefabIndex]);
        currentPrefabIndex = (currentPrefabIndex + 1) % prefabsToInstantiate.Length;
        pickupScript = GameObject.Find("PlayerCam").GetComponent<PickUpScript>();
        scoreSystem = GameObject.Find("ScoreText").GetComponent<ScoreSystem>();
    }

    void OnTriggerEnter(Collider collision)
    {
        bool hasBook = pickupScript.heldObj != null && pickupScript.heldObj.CompareTag("book");
        if (collision.transform.CompareTag("Player"))
        {
            if (scoreSystem.completedLvl)
            {
                if (hasBook)
                {
                    InstructionTime.SetActive(true);
                    Action = true;
                    print("Colliding");
                    print(Action);
                }
                else
                {
                    InstructionGrabBook.SetActive(true);
                    Debug.Log(scoreSystem.completedLvl);
                }
            }
            else
            {
                InstructionPickObjects.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        InstructionTime.SetActive(false);
        InstructionGrabBook.SetActive(false);
        InstructionPickObjects.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {

                    if (pickupScript.heldObj.CompareTag("book"))
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
                        if (closed == false)
                        {
                            AnimejanelaEsq.GetComponent<Animator>().Play("close-window");
                            AnimejanelaDir.GetComponent<Animator>().Play("close-window-dir");
                        }
                    }
                
            }
        }

    }
}