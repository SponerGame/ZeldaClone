using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Vector3 flyingVector;


    void Update()
    {
        Fly();
    }

    private void Fly()
    {
        if(Input.GetKey(KeyCode.E))
        {
            
            characterController.Move(flyingVector * Time.deltaTime) ;
        }


        if (Input.GetKey(KeyCode.Q))
        {

            characterController.Move(-flyingVector * Time.deltaTime);
        }
    }
}
