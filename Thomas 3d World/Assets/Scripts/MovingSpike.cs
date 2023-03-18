using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpike : MonoBehaviour
{
    enum Moving { direct, reverse } ;
    Moving moving;
    
    public float delay;
    public Vector3 direction;

    private void Start()
    {
        moving = Moving.direct;
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

    }
}
