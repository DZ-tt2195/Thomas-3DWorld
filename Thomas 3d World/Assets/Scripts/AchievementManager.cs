using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;
    public bool[] completed = new bool[10];

    /*
    [Tooltip("Beat the game")]
    public bool beatGame;

    [Tooltip("Collect all the jewels")]
    public bool beatGamePlusJewels;

    [Tooltip("Beat the game with the One Jump challenge on")]
    public bool oneJump;

    [Tooltip("Collect all the jewels with the One Jump challenge on")]
    public bool oneJumpPlusJewels;

    [Tooltip("Beat the game with the Timer challenge on")]
    public bool timedGame;

    [Tooltip("Collect all the jewels with the Timer challenge on")]
    public bool timedGamePlusJewels;
    
    [Tooltip("Beat the game with the One Life challenge on")]
    public bool oneLife;

    [Tooltip("Collect all the jewels with the One Life challenge on")]
    public bool oneLifePlusJewels;

    [Tooltip("Beat the game with all challenges on")]
    public bool impossible;

    [Tooltip("Collect all the jewels with all challenges on")]
    public bool impossiblePlusJewels;
    */

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    bool AllCollectibles()
    {
        return UIManager.instance.collectibles == UIManager.instance.allCollectibles.Length;
    }

    public void CheckForAchievements()
    {
        if (Challenges.instance.checkpointLoaded == 0)
        {
            completed[0] = true;
            if (AllCollectibles())
                completed[1] = true;

            if (Challenges.instance.oneJump)
            {
                completed[2] = true;
                if (AllCollectibles())
                    completed[3] = true;
            }

            if (Challenges.instance.timed)
            {
                completed[4] = true;
                if (AllCollectibles())
                    completed[5] = true;
            }

            if (Challenges.instance.oneLife)
            {
                completed[6] = true;
                if (AllCollectibles())
                    completed[7] = true;
            }

            if (Challenges.instance.oneJump && Challenges.instance.timed && Challenges.instance.oneLife)
            {
                completed[8] = true;
                if (AllCollectibles())
                    completed[9] = true;
            }
        }
    }
}