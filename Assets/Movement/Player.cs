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

    private float jumpVector;

    private bool isJumping;

    //New
    float xRot;
    float yRot;
    //

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

    //New
    private Quaternion ViewRotate(Vector2 rotate)
    {
        if ((xRot - rotate.y > -80) && (xRot - rotate.y < 80))
        {
            xRot -= rotate.y;
        }

        yRot += rotate.x;

        return Quaternion.Euler(xRot,yRot, 0f);
    }
    //

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