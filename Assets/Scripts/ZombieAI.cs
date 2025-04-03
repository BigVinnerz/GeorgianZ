// By: Vinny, REFERENCE CODE: Connor Smiley Enemy Script
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private Transform[] waypoints; 
    [SerializeField] private float moveSpeed = 3f; 
    [SerializeField] private float detectRadius = 5f; 

    private int currentWaypoint = 0;
    private bool isChasing = false;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        isChasing = distanceToPlayer <= detectRadius;

        if (isChasing)
        {
            ChasePlayer(); 
        }
        else
        {
            Patrol(); 
        }
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypoint];
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // Check if the zombie has reached the current waypoint
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length; // Move to the next waypoint
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}