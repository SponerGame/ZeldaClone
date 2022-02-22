using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(CharacterController))]

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 moveVector, float rotation)
    {
        characterController.Move(MoveDirection(moveVector, rotation) * moveSpeed * Time.fixedDeltaTime);
    }

    public void MoveOnLadder(Vector2 moveVector)
    {
        characterController.Move(new Vector3(0, moveVector.y, 0) * moveSpeed * Time.fixedDeltaTime);
    }

    private Vector3 MoveDirection(Vector2 direction, float rotation)
    {
        return Quaternion.Euler(0, rotation, 0) * new Vector3(direction.x, 0, direction.y);
    }
}
