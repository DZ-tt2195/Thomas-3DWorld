using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    bool triggered = false;
    public float timer;
    Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
    }

    public void Reset()
    {
        transform.position = originalPos;
        triggered = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(timer);
        triggered = true;
    }

    private void Update()
    {
        if (triggered)
            transform.Translate(new Vector3(0, -0.02f, 0), Space.Self);
    }
}
