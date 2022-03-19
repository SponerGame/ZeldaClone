using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject currentItem;

    public static GameObject gun;

    private CharacterInputActions input;
    [SerializeField] private Inventory inventory; // на рефактор
    public static MovementController movementController { get; private set; }
    public static CameraController cameraController { get; private set; }
    public static GravityController gravityController { get; private set; }
    public static JumpController jumpController { get; private set; }

    public static UsingController usingController { get; private set; }

    public static Checker checker { get; private set; }

    public static Busters.BusterType activeBuster;

    public enum MovementStatus
    {
        RegularMove,
        OnLadder
    }

    public static MovementStatus currentStatus = MovementStatus.RegularMove;

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
        input.CharacterInputController.Shot.performed += ctx => usingController.TryShot();

        input.CharacterInputController.Jump.performed += ctx => jumpController.TryJump();
    }

    private void FixedUpdate()
    {
        StatusController();
         // на рефактор
        if (input.CharacterInputController.Inventory.IsPressed())
        {
            inventory.Open(input.CharacterInputController.ViewRotate.ReadValue<Vector2>());
        }
        else
        {
            inventory.Close();
        }
        //
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
    }
}