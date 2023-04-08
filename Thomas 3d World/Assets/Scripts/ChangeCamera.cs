using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera newCamera;
    public int zone;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            CameraManager.instance.NewCamera(newCamera, this.gameObject.name, zone);
    }
}
