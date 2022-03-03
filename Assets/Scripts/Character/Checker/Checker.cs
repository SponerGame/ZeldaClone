using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] private Transform areaChecker;
    [SerializeField] private Transform groundCheck;

    private Vector3 areaCheckerSize;

    private void Awake()
    {
        areaCheckerSize = areaChecker.GetComponent<BoxCollider>().size / 2;
    }

    public bool CheckArea(LayerMask mask)
    {
        return Physics.CheckBox(areaChecker.position, areaCheckerSize, areaChecker.rotation, mask);
    }

    public bool CheckIsGround()
    {
        return Physics.CheckSphere(groundCheck.position, 0.5f, LayerMask.GetMask("Ground"));
    }
}
