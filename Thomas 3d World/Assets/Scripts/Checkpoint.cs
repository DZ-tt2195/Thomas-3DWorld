using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool current = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            CheckpointManager.instance.NewCheckpoint(this);
    }

}
