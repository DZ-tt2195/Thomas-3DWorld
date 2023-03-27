using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance = null;
    public bool checkpointSet;
    public GameObject lastCheckpoint;
    float rotate = 0;
    [HideInInspector] public GameObject[] allCheckpoints;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        allCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    public void NewCheckpoint(GameObject x)
    {
        if (x != null && x.transform.parent.name == "END")
        {
            AchievementManager.instance.CheckForAchievements(UIManager.instance.stopwatch.Elapsed);
            SceneManager.LoadScene("Main Menu");
        }

        if (lastCheckpoint != x)
        {
            if (lastCheckpoint != null)
            {
                lastCheckpoint.transform.parent.localEulerAngles = new Vector3(0, 0, 0);
            }

            rotate = 0;
            checkpointSet = true;
            lastCheckpoint = x;

            if (lastCheckpoint != null && !Challenges.instance.oneLife)
                this.transform.position = new Vector3(x.transform.position.x, x.transform.position.y, x.transform.position.z);

            Challenges.instance.stopwatch.Restart();
            Challenges.instance.jumpsLeft = 1;
        }
    }

    private void Update()
    {
        if (lastCheckpoint != null)
        {
            rotate += 3f;
            lastCheckpoint.transform.parent.localEulerAngles = new Vector3(0, rotate, 0);
        }
    }
}
