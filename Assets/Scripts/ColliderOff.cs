using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOff : MonoBehaviour
{
    public Collider collider;

    public void Start()
    {
        StartCoroutine(ColliderOn());
    }

    IEnumerator ColliderOn()
    {
        yield return new WaitForSeconds(0.1f);
        collider.enabled = true;
    }
}
