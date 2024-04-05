using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCarScript : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2;
    private int currentWaypointIndex = 0;

    void Start()
    {
    }

    void Update()
    {
        if (currentWaypointIndex < waypoints.Count)
        {
            MoveTowardsWaypoint();
        }
    }

    void MoveTowardsWaypoint()
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            currentWaypointIndex++;
        }
    }
}
