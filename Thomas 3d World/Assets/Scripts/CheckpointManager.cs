using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Diagnostics;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance = null;
    public bool checkpointSet;
    public Checkpoint lastCheckpoint;
    float rotate = 0;
    public TMP_Text UItext;
    public int deaths = 0;
    public int collectibles = 0;
    Collectible[] allCollectibles;
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

        allCollectibles = FindObjectsOfType(typeof(Collectible)) as Collectible[];
    }

    private void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    public void NewCheckpoint(Checkpoint x)
    {
        if (lastCheckpoint != x)
        {
            if (lastCheckpoint != null)
            {
                lastCheckpoint.current = false;
                lastCheckpoint.transform.rotation = new Quaternion(0, 0, 0, 0);
            }

            rotate = 0;
            checkpointSet = true;
            lastCheckpoint = x;
            lastCheckpoint.current = true;
            this.transform.position = x.transform.parent.position;
        }
    }

    private void Update()
    {
        if (lastCheckpoint != null)
        {
            rotate += 0.5f;
            lastCheckpoint.transform.parent.localEulerAngles = new Vector3(0, rotate, 0);
        }

        UItext.text = $"Time: {ConvertTimeToString(stopwatch.Elapsed)}" +
        $"\nDeaths: {deaths}" +
        $"\nJewels: {collectibles} / {allCollectibles.Length}" +
        $"\nFPS: {CalculateFrames()}";
    }

    string ConvertTimeToString(TimeSpan x)
    {
        string part = x.Seconds < 10 ? $"0{x.Seconds}" : $"{x.Seconds}";
        return $"{x.Minutes}:" + part + $".{x.Milliseconds}";
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
        return lastupdate;
    }
}