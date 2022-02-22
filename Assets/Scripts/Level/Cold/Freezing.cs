using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezing : MonoBehaviour
{

    private float freezeCount = 0;
    [SerializeField] float secondsOfFreezed = 20f;


    private void FixedUpdate()
    {
        Freeze();
        Debug.Log(freezeCount);
        if(IsFreezed())
        {
            Debug.Log("fucking cold is here!!");
        }
    }

    

    private void Freeze()
    {
        if(freezeCount < secondsOfFreezed)
        {
            freezeCount += Time.deltaTime;
        } 
    }


    private bool IsFreezed()
    {
        if(freezeCount >= secondsOfFreezed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Heat()
    { 
            freezeCount = 0;
    }



}
