using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNav : MonoBehaviour
{
    NPCMovement controller;
    public Waypoint currentWaypoint;
    private int direction;

    private void Awake()
    {
        controller = GetComponent<NPCMovement>();
    }

    private void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0f, 1f));
        controller.SetDestination(currentWaypoint.GetPosition());
    }
    private void Update()
    {
        if (controller.reachedDestination)
        {
            
            //should take path??
            bool shouldBranch = false;
            if(currentWaypoint.branches != null && currentWaypoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
            }

            if (shouldBranch)
            {
                currentWaypoint = currentWaypoint.branches[Random.Range(0, currentWaypoint.branches.Count - 1)];
            }

            else
            {
                if (currentWaypoint.oneDirection)
                {
                    direction = currentWaypoint.direction;
                }

                if (direction == 0)
                {
                    if (currentWaypoint.nextWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                        direction = 1;
                    }
                }
                else if (direction == 1)
                {
                    if (currentWaypoint.nextWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.nextWaypoint;
                        direction = 0;
                    }
                }
            }

            controller.SetDestination(currentWaypoint.GetPosition());
            //check if wait
            if (currentWaypoint.previousWaypoint.wait)
            {
                controller.Wait();
            }

        }
    }
}
