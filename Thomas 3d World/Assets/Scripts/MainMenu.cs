using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<Toggle> challenges = new List<Toggle>();
    public List<Toggle> completed = new List<Toggle>();
    Button playGame;
    Button achievements;
    GameObject bigImage;

    private void Awake()
    {
        playGame = GameObject.Find("Play Game").GetComponent<Button>();
        achievements = GameObject.Find("Achievements").GetComponent<Button>();
        bigImage = GameObject.Find("Big Image").gameObject; 
    }

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

        SceneManager.LoadScene(1);
    }
}
