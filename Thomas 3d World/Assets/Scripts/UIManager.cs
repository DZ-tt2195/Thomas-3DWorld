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
    public int deaths = 0;
    public int collectibles = 0;

    GameObject[] allCollectibles;
    float rotate = 0;
    Stopwatch stopwatch;

    int lastframe = 0;
    int lastupdate = 60;
    float[] framearray = new float[60];

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

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
        $"\nFPS: {CalculateFrames()}";

        rotate += 0.5f;
        for (int i = 0; i < allCollectibles.Length; i++)
        {
            allCollectibles[i].gameObject.transform.localEulerAngles = new Vector3(90, 0, rotate);
        }
    }

    string ConvertTimeToString(TimeSpan x)
    {
        string part = x.Seconds < 10 ? $"0{x.Seconds}" : $"{x.Seconds}";
        return $"{x.Minutes}:" + part;
    }

    int CalculateFrames()
    {
        framearray[lastframe] = Time.deltaTime;
        lastframe = (lastframe + 1);
        if (lastframe == 60)
        {
            lastframe = 0;
            float total = 0;
            for (int i = 0; i < framearray.Length; i++)
                total += framearray[i];
            lastupdate = (int)(framearray.Length / total);
            return lastupdate;
        }
        return (lastupdate <= 60) ? lastupdate : 60;
    }
}
