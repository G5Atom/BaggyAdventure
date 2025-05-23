using System;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform aiTargets;

    private int currentWaypointindex = 0;
    private float previousXPosition;
    public SpriteRenderer sprite;

    private void Start()
    {
        aiTargets.position = waypoints[0].position;
        sprite.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        SwitchTargetToNextWaypoint();
        FaceMovementDirection();
    }

    private void SwitchTargetToNextWaypoint() 
    {
        float distanceToTarget = Vector3.Distance(transform.position, aiTargets.position);

        bool isCloseToTarget = distanceToTarget < 1f;

        if (isCloseToTarget) 
        {
            currentWaypointindex = currentWaypointindex + 1;

            bool indexIsOutOfRange = currentWaypointindex >= waypoints.Length;
            if (indexIsOutOfRange) 
            {
                currentWaypointindex = 0;
            }

            aiTargets.position = waypoints[currentWaypointindex].position;
        }
    }

    private void FaceMovementDirection() 
    {
        bool shouldFlipX = transform.position.x > previousXPosition;
        sprite.flipX = shouldFlipX;     
       previousXPosition = transform.position.x;
    }
}
