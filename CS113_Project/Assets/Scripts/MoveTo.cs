using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

    public Transform goal;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
      agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
      

    }

    // Update is called once per frame
    void Update () {
        agent.destination = goal.position;
    }
}
