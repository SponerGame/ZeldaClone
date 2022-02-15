using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCalculator : MonoBehaviour
{
    private float xRotation;
    private float yRotation;

    private static readonly float limitAngle = 80;

    public Quaternion ViewRotation(Vector2 inputRotation, float rotationSpeed)
    {
        if (IsRotatable(inputRotation))
        {
            xRotation -= inputRotation.y * rotationSpeed * Time.fixedDeltaTime;
        }

        yRotation += inputRotation.x * rotationSpeed * Time.fixedDeltaTime;
    
        return Quaternion.Euler(xRotation, yRotation, 0f);
    }

    private bool IsRotatable(Vector2 inputRotation)
    {
        return (xRotation - inputRotation.y > -limitAngle) && (xRotation - inputRotation.y < limitAngle);
    }
}
