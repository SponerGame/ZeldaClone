using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCubeOnPedestal : Interactable
{
    [SerializeField] private Material material;

    private GameObject item;

    public override void Interact()
    {
        if (PlayerController.currentItem != null)
        {
            item = PlayerController.currentItem;

            if (item.GetComponent<Renderer>().material.color == material.color)
            {
                if (item.GetComponent<Rigidbody>() != null)
                {
                    item.GetComponent<Rigidbody>().useGravity = false;
                    item.GetComponent<Rigidbody>().isKinematic = true;
                }

                item.transform.parent = gameObject.transform;
                item.transform.position = gameObject.transform.position + new Vector3(0, 2, 0);

                PlayerController.currentItem = null;

                StartCoroutine(StartSpening());
            }
        }
    }

    private IEnumerator StartSpening()
    {
        while (item.transform.parent == gameObject.transform)
        {
            item.transform.Rotate(0, 1, 0);

            yield return new WaitForFixedUpdate();
        }
    }
}
