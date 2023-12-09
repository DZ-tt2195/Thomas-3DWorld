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
    public int jumpsLeft;

    public bool timed;
    public Stopwatch stopwatch;
    public AudioClip timer;
    bool timerPlaying;

    public bool oneLife;
    public int checkpointLoaded;

    public int[] levelDeath = new int[7];


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
        jumpsLeft = oneJump ? 1 : 3;
    }

    int CalculateTime()
    {
        if (15 - stopwatch.Elapsed.Seconds < 0)
            return 0;
        else
            return 15 - stopwatch.Elapsed.Seconds;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            if (challengeText == null)
                challengeText = GameObject.Find("Challenge UI").GetComponent<TMP_Text>();

            challengeText.text = "";
            challengeText.transform.parent.gameObject.SetActive(false);

            if (oneJump)
            {
                challengeText.transform.parent.gameObject.SetActive(true);
                challengeText.text += $"-One Jump Challenge\n";

            }
            if (timed)
            {
                challengeText.transform.parent.gameObject.SetActive(true);
                challengeText.text += $"-15sec Timer Challenge\n" +
                    $"({CalculateTime()} seconds)\n";

                if (CalculateTime() == 5 && !timerPlaying)
                {
                    timerPlaying = true;
                    AudioManager.instance.PlaySound(timer, 0.5f);
                }
                else if (CalculateTime() > 5)
                    timerPlaying = false;
            }
            if (oneLife)
            {
                challengeText.transform.parent.gameObject.SetActive(true);
                challengeText.text += $"-One Life Challenge\n";
            }

        }
    }
}
