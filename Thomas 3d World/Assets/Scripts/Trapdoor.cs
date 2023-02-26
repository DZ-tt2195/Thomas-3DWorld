using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    enum State { waiting, move, done };
    State myState;

    public float delay;
    public float stopMoving;

    Vector3 originalPos;
    public Vector3 direction;

    private void Start()
    {
        myState = State.waiting;
        originalPos = transform.position;
        direction = new Vector3(direction.x / 100f, direction.y / 100f, direction.z / 100f);
    }

    public void Reset()
    {
        transform.position = originalPos;
        myState = State.waiting;
        StopCoroutine(Stop());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (myState == State.waiting && other.CompareTag("Player"))
            StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(delay);
        myState = State.move;
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(stopMoving);
        myState = State.done;
    }

    private void Update()
    {
        if (myState == State.move)
            transform.Translate((direction), Space.Self);
    }
}
