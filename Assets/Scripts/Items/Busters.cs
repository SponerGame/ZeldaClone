using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busters : MonoBehaviour
{
    public enum BusterType
    {
        NULL,
        DubleJump,
        HightSpeed
    }

    [SerializeField] private BusterType busterType;
    [SerializeField] private float timeDuration = 10f;

    private bool isActive = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (isActive)
        {
            StopCoroutine(EnableBuster());
            StartCoroutine(EnableBuster());
        }
        else
        {
            StartCoroutine(EnableBuster());
        }
    }

    private IEnumerator EnableBuster()
    {
        isActive = true;

        float timer = 0f;

        PlayerController.activeBuster = busterType;

        while (timer < timeDuration)
        {
            //Debug.Log(timer);

            timer += Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        isActive = false;

        PlayerController.activeBuster = BusterType.NULL;
    }
}
