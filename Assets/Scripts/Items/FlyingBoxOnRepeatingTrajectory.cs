using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBoxOnRepeatingTrajectory : FlyingBoxOnTrajectory
{
    [SerializeField] private float idleTime;

    protected new void Update()
    {
        if (isMoving)
        {
            move();
        }
        else if (!isInteracted)
        {
            timer += Time.deltaTime;

            if (timer > stepTime)
            {
                if (trajectoryStep == trajectory.Length)
                {
                    trajectoryStep = 0;
                }

                destination = getDestination(trajectory[trajectoryStep++]);
                isMoving = true;
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer > idleTime)
            {
                Debug.Log("stop idle");
                isInteracted = false;
            }
        }
    }
}
