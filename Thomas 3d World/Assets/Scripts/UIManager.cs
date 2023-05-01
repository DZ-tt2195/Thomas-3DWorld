using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using Unity.Jobs;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public TMP_Text UItext;
    public GameObject finished;
    public TMP_Text dataByLevel;
    public Button finishButton;

    [HideInInspector] public int deaths = 0;
    public GameObject[] allCollectibles;
    public List<RawImage> jewelImage = new List<RawImage>();

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
        dataByLevel.text = $"Deaths / Time by level:" +
        $"\n1. Breaking In: {Challenges.instance.levelDeath[0]} / {ConvertToLevelTime(0)}" +
        $"\n2. Inside the Temple Walls: {Challenges.instance.levelDeath[1]} / {ConvertToLevelTime(1)}" +
        $"\n3. Ride in the Dark: {Challenges.instance.levelDeath[2]} / {ConvertToLevelTime(2)}" +
        $"\n4. Watch for Rolling Rocks: {Challenges.instance.levelDeath[3]} / {ConvertToLevelTime(3)}" +
        $"\n5. Downwards Domino: {Challenges.instance.levelDeath[4]} / {ConvertToLevelTime(4)}" +
        $"\n6. Fight the Movement: {Challenges.instance.levelDeath[5]} / {ConvertToLevelTime(5)}" +
        $"\n7. Crypt o' Currency: {Challenges.instance.levelDeath[6]} / {ConvertToLevelTime(6)}";
    }

    private void Update()
    {
        UItext.text = $"Time: {ConvertTimeToString(stopwatch.Elapsed)}" +
        $"\nJumps: {CalculateJumps()} " +
        $"\nJewels:" +
        $"\nDeaths: {deaths}" +
        $"\nFPS: {CalculateFrames():F2}";

        rotate += (UnityEngine.Random.Range(0, 1) == 0) ? 5 : -5;

        for (int i = 0; i < allCollectibles.Length; i++)
        {
            allCollectibles[i].gameObject.transform.localEulerAngles = new Vector3(rotate, rotate, rotate);
        }
    }

    public string ConvertToLevelTime(int n)
    {
        return ConvertTimeToString(CameraManager.instance.timePerLevel[n].Elapsed);
    }

    public string ConvertTimeToString(TimeSpan x)
    {
        string part1 = x.Seconds < 10 ? $"0{x.Seconds}" : $"{x.Seconds}";
        string part2 = "";
        if (x.Milliseconds < 10)
            part2 = $"00{x.Milliseconds}";
        else if (x.Milliseconds < 100)
            part2 = $"0{x.Milliseconds}";
        else
            part2 = x.Milliseconds.ToString();

        return $"{x.Minutes}:{part1}.{part2}";
    }

    string CalculateJumps()
    {
        return $"{Challenges.instance.jumpsLeft.ToString()} / {(Challenges.instance.oneJump ? 1 : 3)}";
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
