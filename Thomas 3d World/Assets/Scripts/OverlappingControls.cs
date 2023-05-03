using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverlappingControls : MonoBehaviour
{
    public static OverlappingControls instance;
    public List<TMP_Text> collisions = new List<TMP_Text>();
    public TMP_Text error;
    string collision;

    public AudioClip errorSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Ping();
    }

    public void Ping()
    {
        CheckForErrors();
        if (collision == "")
        {
            MainMenu.instance.PlayMenu();
            error.text = "";
        }
        else
        {
            error.text = $"Warning: Your {collision} key is being used multiple times. \nGame may be buggy as a result.";
            AudioManager.instance.PlaySound(errorSound, 0.5f);
        }
    }

    void CheckForErrors()
    {
        List<string> usedKeys = new List<string>();
        usedKeys.Add("W");
        usedKeys.Add("A");
        usedKeys.Add("S");
        usedKeys.Add("D");
        usedKeys.Add("Up Arrow");
        usedKeys.Add("Left Arrow");
        usedKeys.Add("Down Arrow");
        usedKeys.Add("Right Arrow");

        for (int i = 0; i < collisions.Count; i++)
        {
            string nextText = collisions[i].text;
            for (int j = 0; j<usedKeys.Count; j++)
            {
                if (usedKeys[j] == nextText)
                {
                    collision = nextText;
                    return;
                }
            }
            usedKeys.Add(nextText);
        }

        collision = "";
    }
}