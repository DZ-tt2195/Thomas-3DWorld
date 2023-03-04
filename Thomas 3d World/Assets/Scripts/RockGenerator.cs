using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    public GameObject rockclone;
    public Rock.Direction rockDirection;
    public enum RockLayer { Default, Orange, Blue };
    public RockLayer spawnLayer;
    public float rockScale;
    public float delay;
    public float rockSpeed;

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
        newRock.GetComponentInChildren<Rock>().RockSetup(rockDirection, spawnLayer.ToString(), rockSpeed);

        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnRock());
    }
}
