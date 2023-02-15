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

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

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
    }
}
