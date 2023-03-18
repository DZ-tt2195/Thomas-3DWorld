using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class Challenges : MonoBehaviour
{
    public static Challenges instance;
    TMP_Text challengeText;

    public bool oneJump;
    [HideInInspector]public int jumpsLeft = 1;

    public bool timed;
    public Stopwatch stopwatch;

    public bool oneLife;
    public int checkpointLoaded;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            if (challengeText == null)
                challengeText = GameObject.Find("Challenge UI").GetComponent<TMP_Text>();

            challengeText.text = "";
            challengeText.transform.parent.gameObject.SetActive(false);

            if (checkpointLoaded > 0)
            {
                challengeText.transform.parent.gameObject.SetActive(true);
                challengeText.text += $"-Loaded from a checkpoint\n(Achievements disabled)\n";
            }

            if (oneJump)
            {
                challengeText.transform.parent.gameObject.SetActive(true);
                challengeText.text += $"-One Jump Challenge\n";
                if (jumpsLeft == 1)
                    challengeText.text += $"(1 jump left)\n";
                else
                    challengeText.text += $"(0 jumps left)\n";
            }
            if (timed)
            {
                challengeText.transform.parent.gameObject.SetActive(true);
                challengeText.text += $"-15sec Timer Challenge\n" +
                    $"({15 - stopwatch.Elapsed.Seconds} seconds left)\n";
            }
            if (oneLife)
            {
                challengeText.transform.parent.gameObject.SetActive(true);
                challengeText.text += $"-One Life Challenge\n";
            }
        }
    }
}
