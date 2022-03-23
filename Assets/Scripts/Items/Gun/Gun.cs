using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Interactable
{
    [SerializeField] private Camera characterCamera;

    public override void Interact()
    {
        if (PlayerController.currentItem != null)
        {
            PlayerController.currentItem.GetComponent<GetItem>().DropItem();
        }

        PlayerController.gun = gameObject;

        gameObject.transform.parent = characterCamera.transform;

        Show();
    }

    public void Show()
    {
        gameObject.transform.localEulerAngles = new Vector3(90, 0, 0);

        gameObject.transform.position = characterCamera.transform.position + characterCamera.transform.forward;
        gameObject.transform.localPosition += new Vector3(0.6f, -0.4f, 0);
    }

    public void Hide()
    {
        gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);

        gameObject.transform.position = characterCamera.transform.position + characterCamera.transform.forward;
        gameObject.transform.localPosition += new Vector3(0, 0, -2f);
    }

    public void Shot()
    {
        if (Physics.Raycast(PlayerController.cameraController.getCharacterCamera().transform.position,
            PlayerController.cameraController.getCharacterCamera().transform.forward, out var hitInfo))
        {
            if (hitInfo.transform.GetComponent<Shootable>() != null)
            {

                hitInfo.transform.GetComponent<Shootable>().AfterShoot();
            }
        }
    }
}
