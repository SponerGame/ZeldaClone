using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBox : Interactable
{
    protected GameObject playerCamera;

    [SerializeField] protected float moveDistance;
    [SerializeField] protected float moveSpeed;

    protected Vector3 destination;

    protected bool isMoving;

    protected void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    protected void Update()
    {
        if (isMoving)
        {
            move();
        }
    }

    protected void move()
    {
        if (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            isMoving = false;
        }
    }

    protected Vector3 getDestination(Vector3Int direction)
    {
        if (Physics.BoxCast(transform.position, GetComponent<BoxCollider>().size / 2.02F, direction, out var hitInfo, transform.rotation, moveDistance) && hitInfo.transform.GetComponent<Collider>() && !hitInfo.transform.GetComponent<CharacterController>())
        {
            return transform.position - (Vector3)direction * moveDistance;
        }
        else if (Physics.BoxCast(transform.position, GetComponent<BoxCollider>().size / 2.02F, direction * (-1), out hitInfo, transform.rotation, moveDistance) && hitInfo.transform.GetComponent<Collider>() && !hitInfo.transform.GetComponent<CharacterController>())
        {
            return transform.position;
        }
        else
        {
            return transform.position + (Vector3)direction * moveDistance;
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
        isMoving = true;
    }
}
