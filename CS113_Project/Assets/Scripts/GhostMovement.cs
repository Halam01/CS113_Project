using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour
{

    public Transform goal;
    NavMeshAgent agent;
    public bool hit;
    public string ghost_id;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hit = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            agent.destination = goal.position;
        }

    }
}