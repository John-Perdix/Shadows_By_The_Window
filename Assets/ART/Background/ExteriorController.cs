using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExteriorController : MonoBehaviour
{
    public GameObject[] backgroundPrefabs;   // Array of background prefabs
    public GameObject[] middlegroundPrefabs; // Array of middleground prefabs
    public GameObject[] foregroundPrefabs;   // Array of foreground prefabs
    public GameObject[] elementPrefabs;      // Array of element prefabs


    private GameObject currentBackgroundInstance;
    private GameObject currentMiddlegroundInstance;
    private GameObject currentForegroundInstance;
    private GameObject currentElementInstance;


    public GameObject InstructionTime;
    public GameObject ThisTrigger;
    public AudioSource SoundFX;
    public bool Action = false;
    public GameObject AnimeObject1;


    public PressKeyOpenDoor pressKeyOpenDoor;
    public GameObject AnimejanelaEsq;
    public GameObject AnimejanelaDir;


    void Start()
    {
        RandomizeScene();
    }

    void Update()
    {
        // For demonstration, let's say we randomize the scene on space bar press
        if (Input.GetKeyDown(KeyCode.E))
        {
            RandomizeScene();
            CheckJanela();
        }
    }

    void RandomizeScene()
    {
        if (Action == true)
        {
            InstructionTime.SetActive(false);
            AnimeObject1.GetComponent<Animator>().Play("ClockAnime");
            //ThisTrigger.SetActive(false);
            SoundFX.Play();

            // Destroy current instances if they exist
            if (currentBackgroundInstance != null) Destroy(currentBackgroundInstance);
            if (currentMiddlegroundInstance != null) Destroy(currentMiddlegroundInstance);
            if (currentForegroundInstance != null) Destroy(currentForegroundInstance);
            if (currentElementInstance != null) Destroy(currentElementInstance);

            // Instantiate new random prefabs
            currentBackgroundInstance = InstantiateRandomPrefab(backgroundPrefabs);
            currentMiddlegroundInstance = InstantiateRandomPrefab(middlegroundPrefabs);
            currentForegroundInstance = InstantiateRandomPrefab(foregroundPrefabs);
            currentElementInstance = InstantiateRandomPrefab(elementPrefabs);
        }
    }

    GameObject InstantiateRandomPrefab(GameObject[] prefabs)
    {
        if (prefabs.Length == 0) return null;
        int randomIndex = Random.Range(0, prefabs.Length);
        return Instantiate(prefabs[randomIndex], transform.position, transform.rotation);
    }

    void CheckJanela()
    {
        pressKeyOpenDoor = FindObjectOfType<PressKeyOpenDoor>();
        bool closed = pressKeyOpenDoor.windowClosed;
        if (closed == false)
        {
            AnimejanelaEsq.GetComponent<Animator>().Play("close-window");
            AnimejanelaDir.GetComponent<Animator>().Play("close-window-dir");
        }
    }
}

