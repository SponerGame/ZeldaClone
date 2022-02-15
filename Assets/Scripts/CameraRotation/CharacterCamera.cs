using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    private Camera characterCamera;

    private void Awake()
    {
        characterCamera = GetComponent<Camera>();
    }


    public void Rotation(Quaternion quaternion)
    {
        characterCamera.transform.rotation = quaternion;
    }


    public float GetRotatePosition()
    {
        return characterCamera.transform.eulerAngles.y;
    }


}
