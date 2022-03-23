using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] private SpriteRenderer Lock;
    [SerializeField] private SpriteRenderer Bullet;
    [SerializeField] private SpriteRenderer Effect;

    private void Awake()
    {
        Effect.gameObject.SetActive(false);

    }
    
    private void OnMouseOver()
    {
        Effect.gameObject.SetActive(true);
    }

    public void SetActive()
    {
        isActive = true;
    }

    private void Visualization()
    {
        if(isActive)
        {
            Lock.gameObject.SetActive(false);
            Bullet.gameObject.SetActive(true);
        }
    }
}
