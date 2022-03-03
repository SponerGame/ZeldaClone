using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(CharacterController))]

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    public static bool isJumping = false;

    public static CharacterController characterController;
    
    private Ray groundCheckerRay;
    private RaycastHit hit;

    private Vector3 moveDirection;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 moveVector, float rotation)
    {
        if (isJumping && PlayerController.checker.CheckArea(LayerMask.GetMask("Ground")) == true)
        {
            moveDirection = MoveDirection(moveVector, rotation);
            groundCheckerRay = new Ray(characterController.transform.position + new Vector3(0, -1, 0), moveDirection);

            if (!Physics.Raycast(groundCheckerRay, out hit, 1f, LayerMask.GetMask("Ground")))
            {
                characterController.Move(moveDirection * moveSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            characterController.Move(MoveDirection(moveVector, rotation) * moveSpeed * Time.fixedDeltaTime);
        }
        
        if (PlayerController.checker.CheckIsGround())
        {
            isJumping = false;
        }
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
