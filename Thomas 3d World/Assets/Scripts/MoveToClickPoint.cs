using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    public Animator ani;

    public float speed;

    public Transform playerObject;

    Vector3 home;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Cursor.lockState = CursorLockMode.Confined;
        ani.applyRootMotion = true;
        home = transform.position;
    }

    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;

            }
        }
        */

        if ((playerObject.gameObject.layer == 8 && this.gameObject.layer == 3) ||
            playerObject.gameObject.layer == 9 && this.gameObject.layer == 6)
            agent.destination = home;
        else
            agent.destination = playerObject.position;
    }

    private void FixedUpdate()
    {
        float objectSpeed = GetComponent<NavMeshAgent>().velocity.magnitude;

        //ani.SetFloat("Speed", objectSpeed);

        //print(speed);
    }
}
