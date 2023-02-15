using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshStore : MonoBehaviour
{
   public List<Material> listOfMaterials = new List<Material>();
    public static MeshStore instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
