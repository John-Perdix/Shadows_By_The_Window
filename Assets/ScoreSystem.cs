using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using System.Globalization;
using UnityEngine.SceneManagement;


public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreValue;
    RandomSpawner randomSpawner;
    public int objectsToPick;
    public bool completedLvl;
    public GameObject foundAll;
    public GameObject canTravel;
    public ClockTimeSystem clockTimeSystem;



    void Start()
    {
        //randomSpawner = GameObject.Find("Spawner").GetComponent<RandomSpawner>();
        scoreText = GetComponent<TextMeshProUGUI>();
        completedLvl = false;
        foundAll.SetActive(false);
        canTravel.SetActive(false);
        clockTimeSystem = GameObject.Find("TriggerBox").GetComponent<ClockTimeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreValue.ToString();
        Debug.Log(scoreValue);
        if (scoreValue >= objectsToPick)
        {
            completedLvl = true;
            foundAll.SetActive(true);
            canTravel.SetActive(true);
        }

        if (clockTimeSystem.Action == true)
        {
            objectsToPick = 14;
            foundAll.SetActive(false);
            canTravel.SetActive(false);
            completedLvl = false;
        }

        if (scoreValue >= 14){
            SceneManager.LoadScene("cutsceneIntro");
        }
    }
}