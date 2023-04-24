using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MeshStore : MonoBehaviour
{
    public List<Material> listOfMaterials = new List<Material>();
    public List<VisualEffectAsset> listOfVisuals = new List<VisualEffectAsset>();
    public static MeshStore instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
