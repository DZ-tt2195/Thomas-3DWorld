using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    bool triggered = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        Debug.Log("trap triggered");
        yield return new WaitForSeconds(3f);
        triggered = true;
    }

    private void Update()
    {
        if (triggered)
            transform.Translate(new Vector3(0, -0.02f, 0), Space.Self);
    }
}
