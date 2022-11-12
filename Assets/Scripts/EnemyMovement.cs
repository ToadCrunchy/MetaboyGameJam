using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool MoveEnemy;
    public bool RotateEnemy;
    public bool ChangeRotateDirection;
    public bool CollisionEffect;
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;
    [SerializeField] float speed = .1f;
    [SerializeField] float rotation = 1f;

    float angle = 0f;

    void Update()
    {
        if (RotateEnemy)
        {
            if (ChangeRotateDirection)
            {
                angle += rotation;
                transform.rotation = Quaternion.Euler(angle, 90, 0);
            }

            if (!ChangeRotateDirection)
            {
                angle -= rotation;
                transform.rotation = Quaternion.Euler(angle, 90, 0);
            }

        }

        if (MoveEnemy)
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        }
    }
}
