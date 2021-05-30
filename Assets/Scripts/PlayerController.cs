using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private NavMeshAgent agent;

    private void Start()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                var h = hit.transform.gameObject;
                

                var g = h.GetComponent<MinedObject>();

                if (g != null)
                {
                    if (Vector3.Distance(transform.position, h.transform.position) <= 2.0f)
                    {
                        g.Mine(15);
                        return;
                    }
                }
                
                agent.SetDestination(hit.point);
            }
        }
    }
}
