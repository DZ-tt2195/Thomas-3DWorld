using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class RockGenerator : MonoBehaviour
{
    public GameObject rockclone;
    public Rock.Direction rockDirection;
    public enum RockLayer { Default, Blue, Yellow };
    public RockLayer spawnLayer;
    public float rockScale;
    public float delay;
    public float rockSpeed;
    public bool playsAudio;
    [ConditionalField(nameof (playsAudio))] public int zone;
    Transform storage;

    private void Awake()
    {
        storage = GameObject.Find("Where Rocks Go").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent<MeshRenderer>());
        StartCoroutine(SpawnRock());
    }

    IEnumerator SpawnRock()
    {
        yield return new WaitForSeconds(0.5f);

        if (playsAudio && zone == CameraManager.instance.currentZone)
            AudioManager.instance.PlaySound(AudioManager.instance.rock, 0.1f);

        GameObject newRock = Instantiate(rockclone);
        newRock.transform.position = this.transform.position;
        newRock.transform.localScale = new Vector3(rockScale, rockScale, rockScale);

        newRock.GetComponentInChildren<Rock>().RockSetup(rockDirection, spawnLayer.ToString(), rockSpeed);
        newRock.transform.SetParent(storage);

        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnRock());
    }
}
