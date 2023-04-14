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
    public int currentZone;
    int currentPriority;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        chapterName = GameObject.Find("Chapter Name").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        currentPriority = currentCamera.Priority;
    }

    public void NewCamera(CinemachineVirtualCamera newCam, string nextChapter, int currentZone)
    {
        this.currentZone = currentZone;
        currentPriority++;
        newCam.Priority = currentPriority;
        currentCamera = newCam;

        if (chapterName.text != nextChapter)
        {
            chapterName.text = nextChapter;
            StopCoroutine(MoveChapter());
            StartCoroutine(MoveChapter());
        }
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
