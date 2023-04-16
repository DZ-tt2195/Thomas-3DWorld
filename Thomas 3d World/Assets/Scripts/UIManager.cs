using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public TMP_Text UItext;
    public GameObject finished;
    public TMP_Text deathsByType;
    public TMP_Text deathsByLevel;
    public Button finishButton;

    [HideInInspector] public int deaths = 0;
    [HideInInspector] public GameObject[] allCollectibles;
    [HideInInspector] public List<RawImage> jewelImage = new List<RawImage>();

    float rotate = 0;
    public Stopwatch stopwatch;

    int lastframe = 0;
    float lastupdate = 60;
    float[] framearray = new float[60];

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Application.targetFrameRate = 60;
        allCollectibles = GameObject.FindGameObjectsWithTag("Jewel");

        for (int i = 0; i < this.transform.childCount; i++)
        {
            jewelImage.Add(this.transform.GetChild(i).GetComponent<RawImage>());
            jewelImage[i].color = new Color(1, 1, 1, 0.2f);
        }
    }

    private void Start()
    {
        finished.SetActive(false);
        stopwatch = new Stopwatch();
        stopwatch.Start();
        finishButton.onClick.AddListener(ReturnToMenu);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Finished()
    {
        finished.SetActive(true);
        deathsByType.text = $"Deaths by type:" +
            $"\nFalling: {Challenges.instance.deathCount[0]}" +
            $"\nSpikes: {Challenges.instance.deathCount[1]}" +
            $"\nRocks: {Challenges.instance.deathCount[2]}" +
            $"\nRestarts: {Challenges.instance.deathCount[3]}";

        deathsByLevel.text = $"Deaths by level:" +
            $"\n1. Breaking In: {Challenges.instance.levelDeath[0]}" +
            $"\n2. Inside the Temple Walls: {Challenges.instance.levelDeath[1]}" +
            $"\n3. Ride in the Dark: {Challenges.instance.levelDeath[2]}" +
            $"\n4. Watch for Rolling Rocks: {Challenges.instance.levelDeath[3]}" +
            $"\n5. Downwards Domino: {Challenges.instance.levelDeath[4]}";
    }

    private void Update()
    {
        UItext.text = $"Time: {ConvertTimeToString(stopwatch.Elapsed)}" +
        $"\nDeaths: {deaths}" +
        $"\nJewels" +
        $"\nFPS: {CalculateFrames():F2}";

        rotate += (UnityEngine.Random.Range(0, 1) == 0) ? 5 : -5;

        for (int i = 0; i < allCollectibles.Length; i++)
        {
            allCollectibles[i].gameObject.transform.localEulerAngles = new Vector3(rotate, rotate, rotate);
        }
    }

    string ConvertTimeToString(TimeSpan x)
    {
        string part = x.Seconds < 10 ? $"0{x.Seconds}" : $"{x.Seconds}";
        return $"{x.Minutes}:" + part;
    }

    float CalculateFrames()
    {
        framearray[lastframe] = Time.deltaTime;
        lastframe = (lastframe + 1);
        if (lastframe == 60)
        {
            lastframe = 0;
            float total = 0;
            for (int i = 0; i < framearray.Length; i++)
                total += framearray[i];
            lastupdate = (float)(framearray.Length / total);
            return lastupdate;
        }
        //return (lastupdate <= 60) ? lastupdate : 60;
        return lastupdate;
    }

    public void EnableJewel(string num)
    {
        jewelImage[int.Parse(num)].color = new Color(1, 1, 1, 1);
    }

    public void DisableJewel(string num)
    {
        jewelImage[int.Parse(num)].color = new Color(1, 1, 1, 0.2f);
    }
}
