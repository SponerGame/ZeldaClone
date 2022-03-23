using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxxx : Shootable
{
    [SerializeField] List<Light> lamps;

    private int color;

    private void Awake()
    {
        foreach (Light i in lamps)
        {
            i.enabled = false;
        }
    }

    public override void AfterShoot()
    {
        foreach (Light i in lamps)
        {
            i.enabled = false;
        }

        switch (Random.Range(0, 3))
        {
            case (0):
                lamps[0].enabled = true;
                break;

            case (1):
                lamps[1].enabled = true;
                break;

            case (2):
                lamps[2].enabled = true;
                break;

            case (3):
                lamps[3].enabled = true;
                break;
        }
    }
}
