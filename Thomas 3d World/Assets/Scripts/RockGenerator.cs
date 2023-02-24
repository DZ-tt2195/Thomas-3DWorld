using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    public GameObject rockclone;
    public Rock.Direction rockDirection;
    public enum RockLayer { Default, Orange, Blue };
    public RockLayer spawnLayer;
    public float scale;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent<MeshRenderer>());
        StartCoroutine(SpawnRock());
    }

    IEnumerator SpawnRock()
    {
        GameObject newRock = Instantiate(rockclone);
        newRock.transform.position = this.transform.position;
        newRock.transform.localScale = new Vector3(scale, scale, scale);
        newRock.GetComponentInChildren<Rock>().RockSetup(rockDirection, spawnLayer.ToString());

        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnRock());
    }
}
