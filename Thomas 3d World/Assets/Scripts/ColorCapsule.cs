using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCapsule : MonoBehaviour
{
    public MeshRenderer md;
    public Light light;

    void Start()
    {
        switch (gameObject.layer)
        {
            case 0: //default
                md.material = MeshStore.instance.listOfMaterials[0];
                light.color = Color.white;
                light.intensity = 200;
                break;
            case 3: //orange
                md.material = MeshStore.instance.listOfMaterials[1];
                light.color = Color.red;
                light.intensity = 200;
                break;
            case 6: //blue
                md.material = MeshStore.instance.listOfMaterials[2];
                light.color = Color.blue;
                light.intensity = 200;
                break;
        }

    }

}
