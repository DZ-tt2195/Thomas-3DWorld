using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    public Animator ani;

    public Transform playerObject;
    float defaultSpeed;

    Vector3 home;

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Cursor.lockState = CursorLockMode.Confined;
        ani.applyRootMotion = true;
        home = transform.position;
        defaultSpeed = agent.speed;
    }

    void Update()
    {
        if ((playerObject.gameObject.layer == 8 && this.gameObject.layer == 3) ||
            playerObject.gameObject.layer == 9 && this.gameObject.layer == 6)
        {
            agent.destination = home;
            agent.speed = 5;
        }
        else
        {
            agent.destination = playerObject.position;
            agent.speed = defaultSpeed;
        }
    }

}
