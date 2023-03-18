using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public List<Toggle> challenges = new List<Toggle>();
    public List<Toggle> completed = new List<Toggle>();
    public GameObject bigImage;

    public Button playGame;
    public Button achievements;
    public TMP_Dropdown dropdown;

    private void Start()
    {
        playGame.onClick.AddListener(SendData);
        achievements.onClick.AddListener(Screen);
        bigImage.SetActive(false);
    }

    public void Screen()
    {
        bigImage.SetActive(!bigImage.activeSelf);
        for (int i = 0; i < completed.Count; i++)
            completed[i].isOn = AchievementManager.instance.completed[i];
    }

    public void SendData()
    {
        Challenges.instance.oneJump = challenges[0].isOn;
        Challenges.instance.timed = challenges[1].isOn;
        Challenges.instance.oneLife = challenges[2].isOn;
        Challenges.instance.checkpointLoaded = dropdown.value;
        SceneManager.LoadScene(0);
    }
}
