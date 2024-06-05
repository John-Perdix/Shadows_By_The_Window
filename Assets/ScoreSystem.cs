using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using System.Globalization;


public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreValue;
    RandomSpawner randomSpawner;
    public int objectsToPick;
    public bool completedLvl;
    public GameObject foundAll;
    


    void Start()
    {
        //randomSpawner = GameObject.Find("Spawner").GetComponent<RandomSpawner>();
        scoreText = GetComponent<TextMeshProUGUI>();
        completedLvl = false;
        foundAll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreValue.ToString();

        if (scoreValue >= objectsToPick)
        {
            completedLvl = true;
            foundAll.SetActive(true);
        }
    }
}