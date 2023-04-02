using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Diagnostics;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public TMP_Text UItext;
    [HideInInspector] public int deaths = 0;
    [HideInInspector] public int collectibles = 0;
    [HideInInspector] public GameObject[] allCollectibles;

    float rotate = 0;
    public Stopwatch stopwatch;

    int lastframe = 0;
    float lastupdate = 60;
    float[] framearray = new float[60];

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Application.targetFrameRate = 60;
        allCollectibles = GameObject.FindGameObjectsWithTag("Jewel");
    }

    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    private void Update()
    {
        UItext.text = $"Time: {ConvertTimeToString(stopwatch.Elapsed)}" +
        $"\nDeaths: {deaths}" +
        $"\nJewels: {collectibles} / {allCollectibles.Length}" +
        $"\nFPS: {CalculateFrames():F2}";

        rotate += (UnityEngine.Random.Range(0, 1) == 0) ? 5 : -5;

        for (int i = 0; i < allCollectibles.Length; i++)
        {
            allCollectibles[i].gameObject.transform.localEulerAngles = new Vector3(rotate, rotate, rotate);
        }
    }

    string ConvertTimeToString(TimeSpan x)
    {
        string part = x.Seconds < 10 ? $"0{x.Seconds}" : $"{x.Seconds}";
        return $"{x.Minutes}:" + part;
    }

    float CalculateFrames()
    {
        framearray[lastframe] = Time.deltaTime;
        lastframe = (lastframe + 1);
        if (lastframe == 60)
        {
            lastframe = 0;
            float total = 0;
            for (int i = 0; i < framearray.Length; i++)
                total += framearray[i];
            lastupdate = (float)(framearray.Length / total);
            return lastupdate;
        }
        //return (lastupdate <= 60) ? lastupdate : 60;
        return lastupdate;
    }
}
