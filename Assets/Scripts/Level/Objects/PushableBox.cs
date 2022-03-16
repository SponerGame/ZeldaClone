using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBox : Interactable
{
    private GameObject playerCamera;

    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;

    private Vector3Int moveDirection;
    private Vector3 destination;
    private bool isMoving;

    private Vector3 startPosition;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        startPosition = transform.position;
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving)
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
    }

    override public void Interact()
    {
        if (!isMoving)
        {
            moveDirection = Vector3Int.RoundToInt(playerCamera.transform.forward);
            moveDirection.y = 0;

            if (Mathf.Abs(moveDirection.x) == Mathf.Abs(moveDirection.z))
            {
                return;
            }

            if (Physics.Raycast(transform.position, moveDirection, out var hitInfo, moveDistance) && hitInfo.transform.GetComponent<Collider>())
            {
                destination = transform.position - (Vector3)moveDirection * moveDistance;
            }
            else
            {
                destination = transform.position + (Vector3)moveDirection * moveDistance;
            }
            isMoving = true;
        }
    }
}
