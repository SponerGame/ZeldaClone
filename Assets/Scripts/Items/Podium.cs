using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podium : Interactable
{
   // [SerializeField] private Material material;
    [SerializeField] private GameObject itemForActive;
    private GameObject item;
    private Puzzle puzzle;

    private void Awake()
    {
        puzzle = GetComponentInParent<Puzzle>();
    }

    public override void Interact()
    {
        if (PlayerController.currentItem != null)
        {
            item = PlayerController.currentItem;

            PlayerController.currentItem = null;

            if (item.GetComponent<Rigidbody>() != null)
            {
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
            }

            item.transform.parent = gameObject.transform;
            item.transform.position = gameObject.transform.position + new Vector3(0, 2, 0);

            PlayerController.currentItem = null;

            StartCoroutine(StartSpening());

            puzzle.PuzzleComplite();
        }
    }

    public bool IsActive()
    {
        if (item == itemForActive)
        {
            return true;
        }
        else
        {
            return false;
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
