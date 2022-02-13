using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpDuration;
    [SerializeField] AnimationCurve yCurve;


    private CharacterMovment characterMovment;
    private MovementControler input;


    private float expiredTime;

    private Vector2 direction;
    private Vector2 rotate;

    private Vector2 rotation;

    private float jumpVector;

    private bool isJumping;


    private void Awake()
    {
        characterMovment = GetComponent<CharacterMovment>();
        input = new MovementControler();
        input.Enable();
    }


    private void Start()
    {
        input.PlayerMovementControler.Jump.performed += ctx => TryJump();
        
        expiredTime = 0f;
        isJumping = false;
    }
    

    private void FixedUpdate()
    {
        direction = input.PlayerMovementControler.Move.ReadValue<Vector2>();
        rotate = input.PlayerMovementControler.ViewRotate.ReadValue<Vector2>();

        characterMovment.UseGravity();
        characterMovment.Move(MoveDirection(direction));
        characterMovment.Rotate(ViewRotate(rotate));
    }


    private Vector3 MoveDirection(Vector2 direction)
    {
        float rotatePosition = characterMovment.GetRotatePosition();

        return Quaternion.Euler(0, rotatePosition, 0) * new Vector3(direction.x, 0, direction.y);
    }


    private Vector3 ViewRotate(Vector2 rotate)
    {
        rotation.y += rotate.x;
        rotation.x = Mathf.Clamp(rotation.x - rotate.y, 0, 0);

        return rotation; 
    }


    private void TryJump()
    {
        if (isJumping == false) 
            StartCoroutine(Jump());
    }


    private IEnumerator Jump()
    {
        float oldOffsetY = 0;
        isJumping = true;

        while (expiredTime < jumpDuration)
        {
            expiredTime += 0.02f;

            float progress = expiredTime / jumpDuration;

            characterMovment.Jump((yCurve.Evaluate(progress) - oldOffsetY));

            oldOffsetY = yCurve.Evaluate(progress);
            yield return new WaitForFixedUpdate();
        }

        expiredTime = 0f;
        isJumping = false;
    }
}








