using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Rigidbody rb;
    public enum Direction { up, down, left, right }
    public Direction direction;

    private void Start()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        switch (direction)
        {
            case Direction.right:
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                break;
            case Direction.left:
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                break;
            case Direction.up:
                rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                break;
            case Direction.down:
                rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Player.instance.Died();
        if (other.CompareTag("Rock"))
            Destroy(transform.parent.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
            Destroy(transform.parent.gameObject);

        switch (direction)
        {
            case Direction.right:
              rb.AddForce(Vector3.right);
                break;
            case Direction.left:
                rb.AddForce(Vector3.left);
                break;
            case Direction.up:
                rb.AddForce(Vector3.forward);
                break;
            case Direction.down:
                rb.AddForce(Vector3.back);
                break;
        }
    }
}
