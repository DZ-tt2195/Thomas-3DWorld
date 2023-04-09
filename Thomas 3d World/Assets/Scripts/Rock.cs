using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Rigidbody rb;
    public enum Direction { forward, backward, left, right }
    public Direction direction;
    public MeshRenderer md1;
    public MeshRenderer md2;
    float multiplier = 1;

    public void RockSetup(Direction dir, string layer, float multiplier)
    {
        this.multiplier = multiplier;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        this.gameObject.layer = LayerMask.NameToLayer(layer);
        this.gameObject.transform.parent.gameObject.layer = LayerMask.NameToLayer(layer);
        direction = dir;

        switch (gameObject.layer)
        {
            case 0: //default
                md1.material = MeshStore.instance.listOfMaterials[0];
                md2.material = MeshStore.instance.listOfMaterials[0];
                break;
            case 3: //orange
                md1.material = MeshStore.instance.listOfMaterials[1];
                md2.material = MeshStore.instance.listOfMaterials[1];
                break;
            case 6: //blue
                md1.material = MeshStore.instance.listOfMaterials[2];
                md2.material = MeshStore.instance.listOfMaterials[2];
                break;
        }

        switch (direction)
        {
            case Direction.right:
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                break;
            case Direction.left:
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                break;
            case Direction.forward:
                rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                break;
            case Direction.backward:
                rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case Direction.right:
              rb.AddForce(Vector3.right * this.multiplier * 7.5f);
                break;
            case Direction.left:
                rb.AddForce(Vector3.left * this.multiplier * 7.5f);
                break;
            case Direction.forward:
                rb.AddForce(Vector3.forward * this.multiplier * 7.5f);
                break;
            case Direction.backward:
                rb.AddForce(Vector3.back * this.multiplier * 7.5f);
                break;
        }
    }
}
