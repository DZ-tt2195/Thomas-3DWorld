using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    public GameObject rockclone;
    public Rock.Direction rockDirection;
    public enum RockLayer { Default, Blue, Yellow };
    public RockLayer spawnLayer;
    public float rockScale;
    public float delay;
    public float rockSpeed;
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
        GameObject newRock = Instantiate(rockclone);
        newRock.transform.position = this.transform.position;
        newRock.transform.localScale = new Vector3(rockScale, rockScale, rockScale);

        if (this.gameObject.name == "Final Boss")
            newRock.GetComponentInChildren<Rock>().RockSetup(new Vector3(Random.Range(-1, 1f), 0, Random.Range(-1, 1f)), rockSpeed);
        else
            newRock.GetComponentInChildren<Rock>().RockSetup(rockDirection, spawnLayer.ToString(), rockSpeed);

        newRock.transform.SetParent(storage);
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnRock());
    }
}
