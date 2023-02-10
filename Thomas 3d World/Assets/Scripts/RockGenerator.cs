using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    public Transform rockclone;
    public Rock.Direction rockDirection;
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
        Transform newRock = Instantiate(rockclone);
        newRock.transform.position = this.transform.position;
        newRock.transform.localScale = new Vector3(scale, scale, scale);
        newRock.GetChild(0).GetComponent<Rock>().direction = rockDirection;
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnRock());
    }
}
