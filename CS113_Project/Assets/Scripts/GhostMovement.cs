using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour
{
    public Transform[] goals;
    public Transform goal;
    public bool isCycle;
    private int goal_i;
    NavMeshAgent agent;
    public bool hit;
    public string ghost_id;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //foreach (GameObject go in GameObject.FindGameObjectsWithTag("LRDest"))
        //{ } want to populate goals with an ordered array of destinations
        hit = false;
        if (goals.Length == 0)
            print("Problem: no destinations for Ghost");
        goal_i = 0;
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (goals.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        goal = goals[goal_i];
        agent.destination = goal.position;

        // Choose the next point in the array as the destination,
        // Cycling to the start if isCycle is enabled
        
        if (isCycle)
        {
            goal_i = (goal_i + 1) % goals.Length;
        }
        else if (goal_i + 1 < goals.Length)
            goal_i = (goal_i + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            if (agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
                print("Ghost is at destination.");
            }
            hit = false;
        }
    }
}