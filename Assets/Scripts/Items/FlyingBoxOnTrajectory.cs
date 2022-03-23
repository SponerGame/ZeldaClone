using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBoxOnTrajectory : FlyingBox
{
    [SerializeField] protected float stepTime;

    [SerializeField] protected Vector3Int[] trajectory;
    protected int trajectoryStep;

    protected float timer;
    protected bool isInteracted;

    protected new void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        isMoving = false;
        isInteracted = false;
        trajectoryStep = 0;
        timer = 0;
    }

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
    }

    protected new void move()
    {
        if (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            isMoving = false;
            timer = 0;
        }
    }

    override public void Interact()
    {
        if (isMoving)
        {
            return;
        }

        Vector3Int direction = Vector3Int.RoundToInt(playerCamera.transform.forward);
        direction.y = 0;

        if (Mathf.Abs(direction.x) == Mathf.Abs(direction.z))
        {
            return;
        }

        destination = getDestination(direction);
        isInteracted = true;
        isMoving = true;
    }
}
