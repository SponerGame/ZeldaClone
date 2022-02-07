using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private MovementController movementController;

    void Update()
    {
        var horizontal = Input.GetAxis(Axis.Horizontal);
        var vertical = Input.GetAxis(Axis.Vertical);

        var jumpButton = Input.GetAxis(Axis.Jump);



        
        movementController.Move(horizontal, vertical);
        movementController.RotateCharacter(Input.mousePosition);
    }

}
