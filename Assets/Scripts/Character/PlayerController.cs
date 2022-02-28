using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform areaChecker;
    [SerializeField] private LayerMask ladderMask;

    private Vector3 areaCheckerSize;

    private CharacterInputActions input;

    private MovementController movementController;
    private CameraController cameraController;
    private GravityController gravityController;
    private JumpController jumpController;

    private UsingController usingController;

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

        areaCheckerSize = areaChecker.GetComponent<BoxCollider>().size / 2;
    }

    private void Start()
    {
        input.CharacterInputController.Use.performed += ctx => usingController.TryUsing();
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
        if ((gravityController.CheckIsGround() == true && input.CharacterInputController.Move.ReadValue<Vector2>().y < 0) || CheckArea(ladderMask) == false)
        {
            Debug.Log("RegularMove");
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
        if (CheckArea(ladderMask) == true)
        {
            Debug.Log("OnLadder");
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

    public bool CheckArea(LayerMask mask)
    {
        return Physics.CheckBox(areaChecker.position, areaCheckerSize, areaChecker.rotation, mask);
    }

    public bool CheckArea()
    {
        return Physics.CheckBox(areaChecker.position, areaCheckerSize, areaChecker.rotation, 3);
    }
}