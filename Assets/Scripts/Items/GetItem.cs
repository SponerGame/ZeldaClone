using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : Interactable
{
    [SerializeField] GameObject characterCamera;
    [SerializeField] GameObject additionalObject;

    public override void Interact()
    {
        if (PlayerController.currentItem != null)
        {
            PlayerController.currentItem.GetComponent<GetItem>().DropItem();

            StartCoroutine(WaitAndGet(0.25f));
        }
        else
        {
            Getter();
        }
    }

    public void DropItem()
    {
        if (additionalObject.GetComponent<Rigidbody>() != null)
        {
            additionalObject.GetComponent<Rigidbody>().freezeRotation = false;
            additionalObject.GetComponent<Rigidbody>().useGravity = true;
            additionalObject.GetComponent<Rigidbody>().isKinematic = false;

            additionalObject.GetComponent<Rigidbody>().AddForce(additionalObject.transform.forward * 10f, ForceMode.Impulse);
        }

        additionalObject.transform.parent = null;
        PlayerController.currentItem = null;
    }

    private void Getter()
    {
        additionalObject.transform.parent = characterCamera.transform;
        additionalObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        if (additionalObject.GetComponent<Rigidbody>() != null)
        {
            additionalObject.GetComponent<Rigidbody>().freezeRotation = true;
            additionalObject.GetComponent<Rigidbody>().useGravity = false;
            additionalObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        additionalObject.transform.position = characterCamera.transform.position + characterCamera.transform.forward;
        additionalObject.transform.localPosition += new Vector3(0.7f, -0.7f, 0);

        PlayerController.currentItem = additionalObject;
    }

    private IEnumerator WaitAndGet(float time)
    {
        float timer = 0f;

        while (timer < time)
        {
            timer += Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        Getter();
    }
}