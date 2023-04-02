using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public CinemachineVirtualCamera currentCamera;
    TMP_Text chapterName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        chapterName = GameObject.Find("Chapter Name").GetComponent<TMP_Text>();
    }

    public void NewCamera(CinemachineVirtualCamera newCam, string nextChapter)
    {
        if (newCam != null)
        {
            newCam.Priority = currentCamera.Priority+1;
            currentCamera = newCam;
        }

        chapterName.text = nextChapter;
        StopCoroutine(MoveChapter());
        StartCoroutine(MoveChapter());
    }

    IEnumerator MoveChapter()
    {
        int currPosition = 600;
        for (int i = 0; i<25; i++)
        {
            currPosition -= 4;
            yield return new WaitForSeconds(0.01f);
            chapterName.transform.parent.localPosition = new Vector3(0, currPosition, 0);
        }

        chapterName.transform.parent.localPosition = new Vector3(0, currPosition, 0);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 25; i++)
        {
            currPosition += 4;
            yield return new WaitForSeconds(0.01f);
            chapterName.transform.parent.localPosition = new Vector3(0, currPosition, 0);
        }

    }
}
