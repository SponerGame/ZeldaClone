using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBox : Interactable
{
    public GameObject playerCamera;

    [SerializeField] public float moveDistance;
    [SerializeField] public float moveSpeed;
    public Vector3Int moveDirection;
    public Vector3 destination;
    bool isMoving;

    public Vector3 startPosition;

    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        startPosition = transform.position;
        isMoving = false;
    }

    void Update()
    {
        if (isMoving)
        {
            if (transform.position != destination)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.fixedDeltaTime);
            }
            else
            {
                Debug.Log("moved to " + transform.position);
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

            Debug.Log("moving to " + destination);
            isMoving = true;
        }
    }
}
