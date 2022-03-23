using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GravityController))]

public class JumpController : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 2f;

    public void TryJump()
    {
        switch (PlayerController.currentStatus)
        {
            case (PlayerController.MovementStatus.RegularMove):
                Jump();
                break;

            case (PlayerController.MovementStatus.OnLadder):
                JumpOnLadder();
                break;
        }
    }

    private void Jump()
    {
        if (PlayerController.checker.CheckIsGround() == true)
        {
            MovementController.isJumping = true;
            PlayerController.gravityController.setVelocity(new Vector3(0, Mathf.Sqrt(jumpHeight * -2f * PlayerController.gravityController.getGravityForce()), 0));
        }
        else if (PlayerController.activeBuster == Busters.BusterType.DubleJump)
        {
            if (MovementController.airJumping == false)
            {
                MovementController.airJumping = true;
                PlayerController.gravityController.setVelocity(new Vector3(0, Mathf.Sqrt(jumpHeight * -2f * PlayerController.gravityController.getGravityForce()), 0));
            }
        }
    }

    private void JumpOnLadder()
    {
        PlayerController.movementController.Move( new Vector2(0, -5), PlayerController.cameraController.GetRotation());
    }
}
