using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GravityController))]

public class JumpController : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 2f;

    public void Jump()
    {
        if (PlayerController.checker.CheckIsGround() == true)
        {
            MovementController.isJumping = true;
            PlayerController.gravityController.setVelocity(new Vector3(0, Mathf.Sqrt(jumpHeight * -2f * PlayerController.gravityController.getGravityForce()), 0));
        }
    }

    public void JumpOnLadder()
    {
        PlayerController.movementController.Move( new Vector2(0, -5), PlayerController.cameraController.GetRotation());
    }
}
