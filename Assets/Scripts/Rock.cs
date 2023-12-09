using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Rigidbody rb;
    public enum Direction { forward, backward, left, right, custom }
    public Direction direction;
    public MeshRenderer md1;
    public MeshRenderer md2;
    float multiplier = 1;
    Vector3 customPush;

    void Start()
    {
        StartCoroutine(DeleteSelf());
    }

    IEnumerator DeleteSelf()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject.transform.parent.gameObject);
    }

    public void RockSetup(Vector3 customPush, float multiplier)
    {
        this.multiplier = multiplier;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        this.gameObject.layer = 0;
        this.gameObject.transform.parent.gameObject.layer = 0;

        md1.material = MeshStore.instance.fancyMaterials[2];
        md2.material = MeshStore.instance.fancyMaterials[2];

        rb.constraints = RigidbodyConstraints.FreezeRotationY;
        direction = Direction.custom;
        this.customPush = customPush;
    }

    public void RockSetup(Direction dir, string layer, float multiplier)
    {
        this.multiplier = multiplier;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        this.gameObject.layer = LayerMask.NameToLayer(layer);
        this.gameObject.transform.parent.gameObject.layer = LayerMask.NameToLayer(layer);
        direction = dir;

        switch (gameObject.layer)
        {
            case 3: //orange
                md1.material = MeshStore.instance.fancyMaterials[0];
                md2.material = MeshStore.instance.fancyMaterials[0];
                break;
            case 6: //blue
                md1.material = MeshStore.instance.fancyMaterials[1];
                md2.material = MeshStore.instance.fancyMaterials[1];
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
        if (other.CompareTag("Rock") && other.name != this.name)
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
              rb.AddForce(6f * this.multiplier * Vector3.right);
                break;
            case Direction.left:
                rb.AddForce(6f * this.multiplier * Vector3.left);
                break;
            case Direction.forward:
                rb.AddForce(6f * this.multiplier * Vector3.forward);
                break;
            case Direction.backward:
                rb.AddForce(6f * this.multiplier * Vector3.back);
                break;
            case Direction.custom:
                rb.AddForce(6f * this.multiplier * customPush);
                break;
        }
    }
}
