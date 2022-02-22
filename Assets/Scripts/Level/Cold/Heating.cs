using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heating : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Freezing>().Heat();
    }
}
