using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using System;
using System.Diagnostics;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public CinemachineVirtualCamera currentCamera;

    TMP_Text chapterName;
    TMP_Text hint;

    public int currentZone;
    int currentPriority;

    public Stopwatch[] timePerLevel = new Stopwatch[7];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        chapterName = GameObject.Find("Chapter Name").GetComponent<TMP_Text>();
        hint = GameObject.Find("HintText").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        currentPriority = currentCamera.Priority;
        for (int i = 0; i < timePerLevel.Length; i++)
            timePerLevel[i] = new Stopwatch();
    }

    public void NewCamera(CinemachineVirtualCamera newCam, string nextChapter, int currentZone)
    {
        this.currentZone = currentZone;
        currentPriority++;
        newCam.Priority = currentPriority;
        currentCamera = newCam;

        for (int i = 0; i < timePerLevel.Length; i++)
            timePerLevel[i].Stop();
        timePerLevel[currentZone].Start();

        if (chapterName.text != nextChapter)
        {
            chapterName.text = nextChapter;
            StopAllCoroutines();
            StartCoroutine(MoveChapter());
        }
    }

    public void HintUpdate(string hint)
    {
        this.hint.text = hint;
    }

    public IEnumerator MoveChapter()
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
