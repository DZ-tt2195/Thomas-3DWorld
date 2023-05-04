using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using MyBox;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    public List<Toggle> challenges = new List<Toggle>();
    public List<Toggle> completed = new List<Toggle>();
    public AudioClip menuSound;

    [Foldout("Other Menus", true)]
    public GameObject controlImage;
    public GameObject challengeImage;
    public GameObject achievementImage;
    public Button closeButton;
    public Button controlButton;
    public Button challengeButton;
    public Button achievementButton;
    public Toggle fullScreen;

    [Foldout("Main Menu", true)]
    public Button playGame;
    public TMP_Dropdown dropdown;
    public GameObject WarningText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playGame.onClick.AddListener(SendData);
        closeButton.onClick.AddListener(CloseMenus);
        CloseMenus();

        controlButton.onClick.AddListener(ControlMenu);
        controlImage.SetActive(false);

        challengeButton.onClick.AddListener(ChallengeMenu);
        challengeImage.SetActive(false);

        achievementButton.onClick.AddListener(AchievementMenu);
        achievementImage.SetActive(false);

        for (int i = 0; i< challenges.Count; i++)
        {
            challenges[i].onValueChanged.AddListener(delegate { PlayMenu(); });
        }

        fullScreen.isOn = Screen.fullScreen;
        fullScreen.onValueChanged.AddListener(delegate { WindowMode(); });
    }

    public void PlayMenu()
    {
        AudioManager.instance.PlaySound(menuSound, 0.5f);
    }

    public void AchievementWarning()
    {
        AudioManager.instance.PlaySound(menuSound, 0.5f);
        WarningText.SetActive(dropdown.value != 0);
    }

    public void CloseMenus()
    {
        controlImage.SetActive(false);
        challengeImage.SetActive(false);
        achievementImage.SetActive(false);
        closeButton.gameObject.SetActive(false);
        PlayMenu();
    }

    public void ControlMenu()
    {
        controlImage.SetActive(true);
        closeButton.gameObject.SetActive(true);
        PlayMenu();
    }

    public void ChallengeMenu()
    {
        challengeImage.SetActive(true);
        closeButton.gameObject.SetActive(true);
        PlayMenu();
    }

    public void AchievementMenu()
    {
        achievementImage.SetActive(true);
        closeButton.gameObject.SetActive(true);
        for (int i = 0; i < completed.Count; i++)
            completed[i].isOn = AchievementManager.instance.completed[i];
        PlayMenu();
    }

    public void SendData()
    {
        PlayMenu();
        Challenges.instance.oneJump = challenges[0].isOn;
        Challenges.instance.timed = challenges[1].isOn;
        Challenges.instance.oneLife = challenges[2].isOn;
        Challenges.instance.checkpointLoaded = dropdown.value;
        for (int i = 0; i < Challenges.instance.levelDeath.Length; i++)
            Challenges.instance.levelDeath[i] = 0;
        SceneManager.LoadScene(1);
    }

    public void ResetAchievements()
    {
        CloseMenus();
        for (int i = 0; i < AchievementManager.instance.completed.Length; i++)
            AchievementManager.instance.completed[i] = false;
        AchievementMenu();
    }

    public void WindowMode()
    {
        Screen.fullScreenMode = (fullScreen.isOn) ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
    }
}
