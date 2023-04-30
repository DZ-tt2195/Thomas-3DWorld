using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public static FinalBoss instance;
    public List<GameObject> Switches;
    public GameObject knights;
    public Transform chestLid;
    GameObject chestPlatform;
    RockGenerator rg;
    bool chestUnlocked = false;

    private void Awake()
    {
        instance = this;
        rg = GetComponent<RockGenerator>();
        chestPlatform = GameObject.Find("Chest Platform").gameObject;
    }

    private void Update()
    {
        if (!chestUnlocked && !Switches[0].activeSelf && !Switches[1].activeSelf)
        {
            knights.SetActive(false);
            rg.turnedOn = false;
            chestUnlocked = true;
            StartCoroutine(ChestIsHere());
        }
    }

    IEnumerator ChestIsHere()
    {
        for (int i = 0; i<200; i++)
        {
            chestPlatform.transform.Translate(0, -0.05f, 0);
            chestLid.transform.Rotate(0, 0, .65f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void Restart()
    {
        StopAllCoroutines();
        chestPlatform.transform.localPosition = new Vector3(-17, 35, 21);
        chestLid.transform.localEulerAngles = new Vector3(0, 0, -130);
        chestUnlocked = false;
        rg.turnedOn = true;
        knights.SetActive(true);
        for (int i = 0; i < Switches.Count; i++)
            Switches[i].SetActive(true);
    }
}
