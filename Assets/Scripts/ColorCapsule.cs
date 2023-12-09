using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ColorCapsule : MonoBehaviour
{
    public MeshRenderer md;
    public VisualEffect ve;

    void Start()
    {
        switch (gameObject.layer)
        {
            case 0: //default
                md.material = MeshStore.instance.listOfMaterials[0];
                break;
            case 3: //blue
                md.material = MeshStore.instance.listOfMaterials[1];
                ve.visualEffectAsset = MeshStore.instance.listOfVisuals[0];
                break;
            case 6: //yellow
                md.material = MeshStore.instance.listOfMaterials[2];
                ve.visualEffectAsset = MeshStore.instance.listOfVisuals[1];
                break;
        }
    }

}
