using System;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform aiTarget;

    private int currentWaypointindex = 0;
    private float previousXPosition;
    public SpriteRenderer sprite;

    private void Start()
    {
        aiTarget.position = waypoints[0].position;
        sprite.GetComponent<Renderer>();
    }

    private void Update()
    {
        SwitchTargetToNextWaypoint();
        FaceMovementDirection();
    }

    private void FaceMovementDirection()
    {
        float distanceToTarget = Vector3.Distance(transform.position, aiTarget.position);

        bool isCloseToTarget = distanceToTarget < 1f;

        if (isCloseToTarget) 
        {
            currentWaypointindex = currentWaypointindex + 1;

            bool indexIsOutOfRange = currentWaypointindex >= waypoints.Length;

            if (indexIsOutOfRange) 
            {
                currentWaypointindex = 0;
            }

            aiTarget.position = waypoints[currentWaypointindex].position;
        }
    }

    private void SwitchTargetToNextWaypoint()
    {
        bool shouldFlipX = transform.position.x < previousXPosition;
        sprite.flipX = shouldFlipX;

        previousXPosition = transform.position.x;
    }
}
