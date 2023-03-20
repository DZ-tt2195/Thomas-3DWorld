using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    public enum State { waiting, move, done };
    public State myState;

    public float delay;
    public float stopMoving;

    Vector3 originalPos;
    public Vector3 direction;

    Vector3 originalRot;
    public Vector3 rotation;

    private void Start()
    {
        myState = State.waiting;
        originalPos = transform.position;
        originalRot = transform.localEulerAngles;
    }

    public void Reset()
    {
        transform.localEulerAngles = originalRot;
        transform.position = originalPos;
        myState = State.waiting;
        StopCoroutine(Delete());
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
        yield return new WaitForSeconds(stopMoving);
        if (myState == State.move)
            myState = State.done;
    }

    private void Update()
    {
        if (myState == State.move)
        {
            transform.Translate(direction * Time.deltaTime, Space.Self);
            transform.Rotate(rotation * Time.deltaTime, Space.Self);
        }
    }
}
