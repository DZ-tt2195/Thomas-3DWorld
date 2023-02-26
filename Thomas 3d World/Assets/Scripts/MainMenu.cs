using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<Toggle> options = new List<Toggle>();
    public Button playGame;

    private void Start()
    {
        playGame.onClick.AddListener(SendData);
    }

    public void SendData()
    {
        Challenges.instance.oneJump = options[0].isOn;
        Challenges.instance.timed = options[1].isOn;
        Challenges.instance.oneLife = options[2].isOn;
        SceneManager.LoadScene(1);
    }
}
