using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(CharacterController))]

public class GravityController : MonoBehaviour
{
    [SerializeField] private protected float gravityForce = -9.8f;
    
    private protected Vector3 velocity;

    public void Gravity()
    {
        if (PlayerController.checker.CheckIsGround() == false)
        {
            velocity.y += gravityForce * Time.fixedDeltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = 0f;
        }

        MovementController.characterController.Move(velocity * Time.fixedDeltaTime);
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
