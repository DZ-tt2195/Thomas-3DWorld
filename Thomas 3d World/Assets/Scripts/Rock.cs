using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Rigidbody rb;
    public enum Direction { forward, backward, left, right }
    public Direction direction;
    public MeshRenderer md;

    private void Start()
    {
        switch (gameObject.layer)
        {
            case 0: //default
                md.material = MeshStore.instance.listOfMaterials[0];
                break;
            case 3: //orange
                md.material = MeshStore.instance.listOfMaterials[1];
                break;
            case 6: //blue
                md.material = MeshStore.instance.listOfMaterials[2];
                break;
        }

        transform.rotation = new Quaternion(0, 0, 0, 0);
        switch (direction)
        {
            case Direction.right:
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
                break;
            case Direction.left:
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
                break;
            case Direction.forward:
                rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
                break;
            case Direction.backward:
                rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case Direction.right:
              rb.AddForce(Vector3.right);
                break;
            case Direction.left:
                rb.AddForce(Vector3.left);
                break;
            case Direction.forward:
                rb.AddForce(Vector3.forward);
                break;
            case Direction.backward:
                rb.AddForce(Vector3.back);
                break;
        }
    }
}
