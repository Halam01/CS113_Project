﻿using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour
{
    public Transform[] DestList;
    public Transform goal;
    public int goal_i;
    public bool isCycle;
    NavMeshAgent agent;
    public bool hit;
    public string ghost_id;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hit = false;
        goal_i = 0;
        if (DestList.Length == 0)
        { print("No destinations given"); }
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (DestList.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = DestList[goal_i].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        if (isCycle)
            goal_i = (goal_i + 1) % DestList.Length;
        else if (goal_i + 1 < DestList.Length)
            goal_i++;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            hit = false;
            if (agent.remainingDistance < 0.5f) //at the destination
                GotoNextPoint();
        }

    }
}