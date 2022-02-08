using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private CharacterMovment characterMovment; 

    private float gravityForce;
    private Vector3 moveVector;
    private Vector3 oldMousePosition;

    private void Start()
    {
        oldMousePosition = Input.mousePosition;
    }

    

    private void Update()
    {
        GravityForced();
    }

    public void Move(float offsetX, float offsetZ)
    {
        MoveX(offsetX);
        MoveY();
        MoveZ(offsetZ);
    }

    private void MoveX(float offsetX)
    {
        Vector3 directional = transform.right; 
        moveVector = offsetX * directional;
        characterMovment.Move(moveVector);
    }

    private void MoveY()
    {
        moveVector.y = gravityForce;
        characterMovment.Move(moveVector);
    }

    private void MoveZ(float offsetY)
    {
        Vector3 directional = 2 * transform.forward; 
        moveVector = offsetY * directional;
        characterMovment.Move(moveVector);
    }

    public void RotateCharacter(Vector3 mousePosition)
    {
        Vector3 offset = mousePosition - oldMousePosition;
        offset.Normalize();
        characterMovment.Rotate((Mathf.Atan2(offset.x, offset.z) * Mathf.Rad2Deg));
        oldMousePosition = Input.mousePosition;
    }

    private void GravityForced()
    {
        if(characterMovment.isGrounded)
            gravityForce -= 20f * Time.deltaTime;
        else
        {
            gravityForce = -1f;
        }
    }
}
