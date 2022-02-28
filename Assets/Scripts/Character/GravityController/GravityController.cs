using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(CharacterController))]

public class GravityController : MonoBehaviour
{
    [SerializeField] private protected float gravityForce = -9.8f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    
    private protected Vector3 velocity;

    private Vector3 groundCheckerSize;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        groundCheckerSize = groundCheck.GetComponent<BoxCollider>().size / 2;
    }

    public bool CheckIsGround()
    {
        return Physics.CheckSphere(groundCheck.position, 0.5f, groundMask);
    }

    public void Gravity()
    {
        if (CheckIsGround() == false)
        {
            velocity.y += gravityForce * Time.fixedDeltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = 0f;
        }

        characterController.Move(velocity * Time.fixedDeltaTime);
    }

    public float getGravityForce()
    {
        return gravityForce;
    }

    public void setVelocity(Vector3 newVelocity)
    {
        velocity = newVelocity;
    }
}
