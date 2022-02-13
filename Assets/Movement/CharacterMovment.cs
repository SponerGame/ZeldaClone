using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CharacterMovment : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravitationForce;

    private Normalization normalization = new Normalization();
    private CharacterController characterController;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    public void Move(Vector3 moveVector)
    {
        characterController.Move(moveVector * normalization.fixedMove(moveSpeed));
    }


    public void Jump(float curveJumpValue)
    {
        characterController.Move(new Vector3(0, curveJumpValue * jumpHeight, 0));
    }


    public void Rotate(Vector2 rotationValue)
    {
        characterController.transform.localEulerAngles = rotationValue;
    }


    public void UseGravity()
    {
        characterController.Move(new Vector3(0, -gravitationForce, 0));
    }


    public float GetRotatePosition()
    {
        return characterController.transform.eulerAngles.y;
    }
}
