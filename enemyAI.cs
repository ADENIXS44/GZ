using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class enemyAI : MonoBehaviour
{

    public Transform target;
    public float Speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currrentWaypoint = 0;
    bool reachEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currrentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currrentWaypoint >= path.vectorPath.Count)
        {
            reachEndOfPath = true;
            return;
        }
        else
        {
            reachEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currrentWaypoint] - rb.position).normalized;
        Vector2 force = direction * Speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currrentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currrentWaypoint++;
        }
    }
   
}
