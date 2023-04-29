using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Knight : MonoBehaviour
{
    public SkinnedMeshRenderer md;
    UnityEngine.AI.NavMeshAgent agent;
    Transform playerPosition;

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerPosition = GameObject.Find("PlayerArmature").transform;
    }

    private void Start()
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

    void Update()
    {
        agent.destination = playerPosition.position;
    }
}
