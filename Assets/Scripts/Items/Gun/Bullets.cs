using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
   private CharacterInputActions input;


    public enum BulletTypes
    {
        Usual,
        Freezing,
        Rocket,
        Chain
    }

    private BulletTypes currentBullet = 0;


    private void Awake()
    {
        input = new CharacterInputActions();
        input.Enable();
    }


    private void Update()
    {
        ChangeBulletOfScroll(input.CharacterInputController.Scroll.ReadValue<Vector2>());
    }


    public void SetBullet(BulletTypes bullet)
    {
        Debug.Log("Переключаю жоско на " + bullet);
        currentBullet = bullet;
    }

    public BulletTypes GetBullet()
    {
        return currentBullet;
    }


    private void ChangeBulletOfScroll(Vector2 inputScrollVector)
    {
        if (inputScrollVector.y > 0)
        {
            NextBullet();
        }
        if (inputScrollVector.y < 0)
        {
            PrevBullet();
        }
        //Debug.Log(currentBullet);
    }

    private BulletTypes NextBullet()
    {

        if (currentBullet != BulletTypes.Chain)
        {
            return currentBullet++;
        }
        
        return currentBullet = BulletTypes.Usual;
    
    }

    private BulletTypes PrevBullet()
    {

        if (currentBullet != BulletTypes.Usual)
        {
            return currentBullet--;
        }

        return currentBullet = BulletTypes.Chain;
    }

    

}
