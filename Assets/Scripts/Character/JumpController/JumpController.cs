using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GravityController))]

public class JumpController : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 2f;

    private GravityController gravityController;
    private MovementController movementController;
    private CameraController cameraController;

    private void Awake()
    {
        gravityController = GetComponent<GravityController>();
        movementController = GetComponent<MovementController>();
        cameraController = GetComponent<CameraController>();
    }

    public void Jump()
    {
        if (gravityController.CheckIsGround())
        {
            movementController.isJumping = true;
            gravityController.setVelocity(new Vector3(0, Mathf.Sqrt(jumpHeight * -2f * gravityController.getGravityForce()), 0));
        }
    }

    public void JumpOnLadder()
    {
        movementController.Move( new Vector2(0, -0.5f), cameraController.GetRotation());
    }
}
