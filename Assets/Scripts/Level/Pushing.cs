using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushing : Interactable
{
    [SerializeField] GameObject additionalObject;

    override public void Interact()
    {
        additionalObject.GetComponent<Animator>().SetTrigger("IsOpen");
    }
}
