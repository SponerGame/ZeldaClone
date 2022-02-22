using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(CameraController))]

public class UsingController : MonoBehaviour
{
    [SerializeField] private float useDistance; 

    private CameraController cameraController;

    private void Awake()
    {
        cameraController = GetComponent<CameraController>();
    }

    public void TryUsing()
    {
        if (Physics.Raycast(cameraController.getCharacterCamera().transform.position, cameraController.getCharacterCamera().transform.forward, out var hitInfo, useDistance))
        {
            if (hitInfo.transform.GetComponent<Interactable>())
            {
                hitInfo.transform.GetComponent<Interactable>().Interact();
            }
        }
    }

    
}
