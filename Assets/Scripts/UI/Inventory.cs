using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Canvas inventory;
    
    private void Awake()
    {
        inventory = GetComponent<Canvas>();
    }

    public void Open(Vector2 mouseInput)
    {
        inventory.gameObject.SetActive(true);
    }

    public void Close()
    {
        inventory.gameObject.SetActive(false);
    }
}
