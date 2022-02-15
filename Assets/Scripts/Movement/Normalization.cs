using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normalization : MonoBehaviour
{
    private static float divisorMovmentSpeed = 10;
    private static float divisorJumpDuration = 15;
    private static float divisorCameraRotation = 15;

    public float fixedMove(float pureMove)
    {
        return pureMove / divisorMovmentSpeed;
    }

    public float fixedJumpDuration(float pureJumpDuration)
    {
        return pureJumpDuration / divisorMovmentSpeed;
    }

    public float fixedCameraRotation(float pureCameraRotation)
    {
        return pureCameraRotation / divisorCameraRotation;
    }
}
