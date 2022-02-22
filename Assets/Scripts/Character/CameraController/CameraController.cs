using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera characterCamera;
    [SerializeField] private float rotationSpeed = 10f;

    private float xRotation;
    private float yRotation;

    private static readonly float limitAngleY = 80;

    public void Rotate(Vector2 inputRotation)
    {
        characterCamera.transform.rotation = ViewRotation(inputRotation);
    }

    public float GetRotation()
    {
        return characterCamera.transform.eulerAngles.y;
    }

    public Camera getCharacterCamera()
    {
        return characterCamera;
    }

    private Quaternion ViewRotation(Vector2 inputRotation)
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
        return (xRotation - inputRotation.y > -limitAngleY) && (xRotation - inputRotation.y < limitAngleY);
    }
}
