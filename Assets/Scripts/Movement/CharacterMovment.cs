using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterMovment : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private float rotationSpeed = 10f;

    [SerializeField] private float jumpHeight = 2f;

    [SerializeField] private float gravityForce = -9.8f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;

    private bool isGrounded;
    private float groundDistance = 0.4f;

    private Normalization normalization;
    
    private CharacterController characterController;

    private void Awake()
    {
        normalization = new Normalization();

        characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 moveVector)
    {
        characterController.Move(moveVector * moveSpeed * Time.fixedDeltaTime);
    }

    public void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!isGrounded)
        {
            velocity.y += gravityForce * Time.fixedDeltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = 0f;
        }

        characterController.Move(velocity * Time.fixedDeltaTime);
    }

    public IEnumerator Jump()
    {
        if (isGrounded)
        {
            do
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityForce);

                yield return new WaitForFixedUpdate();
            }
            while (!isGrounded);
        }
    }

    public float getRotationSpeed()
    {
        return rotationSpeed;
    }
}