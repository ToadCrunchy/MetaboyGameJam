using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareMovement : MonoBehaviour
{
    public bool MoveShare;
    public bool RotateShare;
    public bool CollisionEffect;

    private Rigidbody rb;
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;
    [SerializeField] float speed = .1f;
    [SerializeField] float rotation = .1f;

    float angle = 0f;

    void Update()
    {
        if (RotateShare)
        {
            angle += rotation;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        if (MoveShare)
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