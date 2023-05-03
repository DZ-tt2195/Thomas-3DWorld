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
    public List<GameObject> allCheckpoints = new List<GameObject>();
    public AudioClip checkpointSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void NewCheckpoint(GameObject x)
    {
        if (x != null && x.transform.parent.name == "END")
        {
            AudioManager.instance.PlaySound(checkpointSound, 0.2f);
            AchievementManager.instance.CheckForAchievements(UIManager.instance.stopwatch.Elapsed);
            UIManager.instance.Finished();
            UIManager.instance.stopwatch.Stop();
            Challenges.instance.stopwatch.Stop();
        }

        else if (lastCheckpoint != x)
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

            AudioManager.instance.PlaySound(checkpointSound, 0.2f);
            Challenges.instance.stopwatch.Restart();
            Challenges.instance.jumpsLeft = Challenges.instance.oneJump ? 1 : 3;
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
