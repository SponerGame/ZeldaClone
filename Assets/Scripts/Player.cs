using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Player : MonoBehaviour
{
    private CharacterCamera characterCamera;
    private CharacterMovment characterMovment;
    private MovementControler input;

    private RotationCalculator rotationCalculator;

    private Vector2 inputDirection;
    private Vector2 inputRotate;

    private void Awake()
    {
        rotationCalculator = new RotationCalculator();

        characterMovment = GetComponent<CharacterMovment>();
        characterCamera = GetComponent<CharacterCamera>();

        input = new MovementControler();

        input.Enable();
    }

    private void Start()
    {
        input.PlayerMovementControler.Jump.performed += ctx => TryJump();
    }

    private void FixedUpdate()
    {
        inputDirection = input.PlayerMovementControler.Move.ReadValue<Vector2>();
        inputRotate = input.PlayerMovementControler.ViewRotate.ReadValue<Vector2>();

        characterMovment.Gravity();

        characterMovment.Move(MoveDirection(inputDirection));
        characterCamera.Rotation(rotationCalculator.ViewRotation(inputRotate));
    }

    private Vector3 MoveDirection(Vector2 direction)
    {
        float rotatePosition = characterCamera.GetRotatePosition();

        return Quaternion.Euler(0, rotatePosition, 0) * new Vector3(direction.x, 0, direction.y);
    }

    public void TryJump()
    {
        StartCoroutine(characterMovment.Jump());
    }
}