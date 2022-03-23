using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBox : Interactable
{
    private GameObject playerCamera;

    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stepTime;
    [SerializeField] private float idleTime;

    Vector3 destination;

    [SerializeField] private Vector3Int[] trajectory;
    private int trajectoryStep;

    private float timer;

    private bool isMoving;
    private bool isInteracted;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        isMoving = false;
        isInteracted = false;
        trajectoryStep = 0;
        timer = 0;
    }

    private void Update()
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

    private void move()
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

    private Vector3 getDestination(Vector3Int direction)
    {
        if (Physics.BoxCast(transform.position, GetComponent<BoxCollider>().size / 2F, direction, out var hitInfo, transform.rotation, moveDistance) && hitInfo.transform.GetComponent<Collider>())
        {
            return transform.position - (Vector3)direction * moveDistance;
        }
        else if (Physics.BoxCast(transform.position, GetComponent<BoxCollider>().size / 2F, direction * (-1), out hitInfo, transform.rotation, moveDistance) && hitInfo.transform.GetComponent<Collider>())
        {
            return transform.position + (Vector3)direction * moveDistance;
        }
        else
        {
            return transform.position;
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
