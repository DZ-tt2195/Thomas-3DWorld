using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Diagnostics;

public class Challenges : MonoBehaviour
{
    public static Challenges instance;
    TMP_Text challengeText;

    public bool oneJump;
    [HideInInspector]public int jumpsLeft = 1;

    public bool oneLife;

    public bool timed;
    public Stopwatch stopwatch;

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
        if (challengeText == null)
            challengeText = GameObject.Find("Challenge UI").GetComponent<TMP_Text>();

        challengeText.text = "";
        challengeText.transform.parent.gameObject.SetActive(false);

        if (oneJump)
        {
            challengeText.transform.parent.gameObject.SetActive(true);
            challengeText.text += $"One jump per checkpoint: {jumpsLeft} left\n";
        }
        if (oneLife)
        {
            challengeText.transform.parent.gameObject.SetActive(true);
            challengeText.text += $"Dying restarts the game\n";
        }
        if (timed)
        {
            challengeText.transform.parent.gameObject.SetActive(true);
            challengeText.text += $"Time for this checkpoint: {15 - stopwatch.Elapsed.Seconds}\n";
        }
    }
}
