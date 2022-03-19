using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public enum BulletTypes
    {
        Usual,
        Freezing,
        Rocket,
        Chain
    }

    private BulletTypes currentBullet;

    public void SetBullet(BulletTypes bullet)
    {
        currentBullet = bullet;
    }
}
