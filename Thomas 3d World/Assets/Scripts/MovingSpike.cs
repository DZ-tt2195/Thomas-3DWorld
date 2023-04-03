using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpike : MonoBehaviour
{
    enum Moving { none, direct, reverse } ;
    Moving moving;
    
    public float delay;
    public Vector3 direction;
    Vector3 originalPos;

    private void Start()
    {
        originalPos = this.transform.localPosition;
        moving = Moving.none;
        StartCoroutine(Movement(Moving.direct));
    }

    public void Reset()
    {
        StopAllCoroutines();
        this.transform.localPosition = originalPos;
        StartCoroutine(Movement(Moving.direct));
    }

    IEnumerator Movement(Moving x)
    {
        if (x == Moving.direct)
        {
            moving = Moving.direct;
            yield return new WaitForSeconds(delay);
            StartCoroutine(Movement(Moving.reverse));
        }
        else
        {
            moving = Moving.reverse;
            yield return new WaitForSeconds(delay);
            StartCoroutine(Movement(Moving.direct));
        }
    }

    private void Update()
    {
        if (moving == Moving.direct)
            transform.Translate((direction) * Time.deltaTime, Space.Self);
        else if (moving == Moving.reverse)
            transform.Translate(-1 * Time.deltaTime * (direction), Space.Self);
        else
            transform.Translate(0, 0, 0);
    }
}
