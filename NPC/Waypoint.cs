using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint previousWaypoint;
    public Waypoint nextWaypoint;
    public bool wait;
    public bool oneDirection;
    public int direction = 0;

    [Range(0f,10f)]
    public float width = 2f;

    public List<Waypoint> branches;
    [Range(0f, 1f)]
    public float branchRatio = 0.5f;

    public Vector3 GetPosition()
    {
        Vector3 minBound = transform.position + transform.right * width / 3f;
        Vector3 maxBound = transform.position - transform.right * width / 3f;

        return Vector3.Lerp(minBound, maxBound, Random.Range(0f, 1f));
    }
}
