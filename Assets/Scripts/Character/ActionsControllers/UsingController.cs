using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(CameraController))]

public class UsingController : MonoBehaviour
{
    [SerializeField] private float useDistance;

    public void TryUsing()
    {
        if (Physics.Raycast(PlayerController.cameraController.getCharacterCamera().transform.position,
            PlayerController.cameraController.getCharacterCamera().transform.forward, out var hitInfo, useDistance))
        {
            if (hitInfo.transform.GetComponent<Interactable>() != null)
            {
                hitInfo.transform.GetComponent<Interactable>().Interact();
            }
        }
    }

    public void TryDropItem()
    {
        if (PlayerController.currentItem != null)
        {
            PlayerController.currentItem.GetComponent<GetItem>().DropItem();
        }
    }
}