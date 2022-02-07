using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{

    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speedMove;
    [SerializeField] private float rotationSpeed;

    public bool isGrounded { get; private set; }


    public void Move(Vector3 moveVector)
    {
        characterController.Move(moveVector * speedMove * Time.deltaTime);
    }


    public void Rotate(float rotation)
    {
        characterController.transform.Rotate(0, rotation * rotationSpeed * Time.deltaTime, 0);
    }


    private void OnCollisionEnter(Collision groundCollision)
    {
        var ground = groundCollision.gameObject.GetComponentInParent<Ground>(); 
        if(ground)
        isGrounded = true;
    }

    private void OnCollisionExit(Collision groundCollision)
    {
        var ground = groundCollision.gameObject.GetComponentInParent<Ground>();
        if (ground)
            isGrounded = false;
    }
}
