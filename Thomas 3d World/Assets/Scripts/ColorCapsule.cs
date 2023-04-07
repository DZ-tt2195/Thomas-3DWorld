using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCapsule : MonoBehaviour
{
    public MeshRenderer md;

    void Start()
    {
        switch (gameObject.layer)
        {
            case 0: //default
                md.material = MeshStore.instance.listOfMaterials[0];
                break;
            case 3: //blue
                md.material = MeshStore.instance.listOfMaterials[1];
                break;
            case 6: //yellow
                md.material = MeshStore.instance.listOfMaterials[2];
                break;
        }
    }
}
