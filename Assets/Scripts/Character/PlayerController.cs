using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject currentItem;

    private CharacterInputActions input;

    public static MovementController movementController { get; private set; }
    public static CameraController cameraController { get; private set; }
    public static GravityController gravityController { get; private set; }
    public static JumpController jumpController { get; private set; }

    public static UsingController usingController { get; private set; }

    public static Checker checker { get; private set; }

    private enum MovementStatus
    {
        RegularMove,
        OnLadder
    }

    private MovementStatus currentStatus = MovementStatus.RegularMove;

    private void Awake()
    {
        input = new CharacterInputActions();
        input.Enable();

        movementController = GetComponent<MovementController>();
        cameraController = GetComponent<CameraController>();
        gravityController = GetComponent<GravityController>();
        jumpController = GetComponent<JumpController>();

        usingController = GetComponent<UsingController>();

        checker = GetComponent<Checker>();
    }

    private void Start()
    {
        input.CharacterInputController.Use.performed += ctx => usingController.TryUsing();
        input.CharacterInputController.DropItem.performed += ctx => usingController.TryDropItem();
    }

    private void FixedUpdate()
    {
        StatusController();
    }

    private void StatusController()
    {
        switch(currentStatus)
        {
            case(MovementStatus.RegularMove):
                RegularMove();
                break;

            case (MovementStatus.OnLadder):
                OnLadder();  
                break;
        }            
    }

    private void SetStatus(MovementStatus movementStatus)
    {
        currentStatus = movementStatus;
    }

    private void OnLadder()
    {
        if ((checker.CheckIsGround() == true && input.CharacterInputController.Move.ReadValue<Vector2>().y < 0) || checker.CheckArea(LayerMask.GetMask("Ladder")) == false)
        {
            SetStatus(MovementStatus.RegularMove);
        }

        gravityController.setVelocity(Vector3.zero);

        movementController.MoveOnLadder(input.CharacterInputController.Move.ReadValue<Vector2>());
        cameraController.Rotate(input.CharacterInputController.ViewRotate.ReadValue<Vector2>());
    
        if (input.CharacterInputController.Jump.IsPressed())
        {
            jumpController.JumpOnLadder();
        }
    }

    private void RegularMove()
    {
        if (checker.CheckArea(LayerMask.GetMask("Ladder")) == true)
        {
            SetStatus(MovementStatus.OnLadder);
        }

        gravityController.Gravity();

        cameraController.Rotate(input.CharacterInputController.ViewRotate.ReadValue<Vector2>());
        movementController.Move(input.CharacterInputController.Move.ReadValue<Vector2>(), cameraController.GetRotation());

        if (input.CharacterInputController.Jump.IsPressed())
        {
            jumpController.Jump();
        }
    }
}