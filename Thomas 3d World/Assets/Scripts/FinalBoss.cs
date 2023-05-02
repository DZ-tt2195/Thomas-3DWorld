using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public static FinalBoss instance;
    public List<GameObject> Switches;
    public Transform playerPosition;
    public GameObject knights;
    public Transform chestLid;
    GameObject chestPlatform;
    RockGenerator rg;
    bool chestUnlocked = false;

    public GameObject rockclone;
    public float delay;
    public AudioClip cannonShot;
    public AudioClip powerDown;
    Transform storage;

    private void Awake()
    {
        instance = this;
        rg = GetComponent<RockGenerator>();
        chestPlatform = GameObject.Find("Chest Platform").gameObject;
        storage = GameObject.Find("Where Rocks Go").transform;
    }

    private void Start()
    {
        StartCoroutine(SpawnRock());
    }

    IEnumerator SpawnRock()
    {
        yield return new WaitForSeconds(0.5f);
        if (!chestUnlocked)
        {
            if (CameraManager.instance.currentZone == 6)
                AudioManager.instance.PlaySound(cannonShot, 0.1f);

            GameObject newRock = Instantiate(rockclone);
            newRock.transform.position = this.transform.position;
            newRock.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            float xValue = (playerPosition.position.x < this.transform.position.x) ? (Random.Range(-0.8f, -0.2f)) : Random.Range(0.2f, 0.8f);
            float zValue = (playerPosition.position.z < this.transform.position.z) ? (Random.Range(-0.8f, -0.2f)) : Random.Range(0.2f, 0.8f);

            newRock.GetComponentInChildren<Rock>().RockSetup(new Vector3(xValue, 0, zValue), Random.Range(5f, 10f));
            newRock.transform.SetParent(storage);
        }
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnRock());
    }

    private void Update()
    {
        if (!chestUnlocked && !Switches[0].activeSelf && !Switches[1].activeSelf)
        {
            knights.SetActive(false);
            chestUnlocked = true;
            StartCoroutine(ChestIsHere());
        }
    }

    IEnumerator ChestIsHere()
    {
        AudioManager.instance.PlaySound(powerDown, 0.5f);
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
        knights.SetActive(true);
        for (int i = 0; i < Switches.Count; i++)
            Switches[i].SetActive(true);
        StartCoroutine(SpawnRock());
    }
}
