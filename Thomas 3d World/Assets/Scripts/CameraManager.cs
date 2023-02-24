using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public CinemachineVirtualCamera currentCamera;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void NewCamera(CinemachineVirtualCamera newCam)
    {
        if (newCam != null)
        {
            newCam.Priority = currentCamera.Priority+1;
            currentCamera = newCam;
        }
    }
}
