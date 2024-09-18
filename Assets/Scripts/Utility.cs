using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public const int MAX_HEALTH = 6;
    public const float ATTACK_LEN = 0.6f;

    public enum Facing
    {
        North = 180,
        East = 90,
        South = 0,
        West = 270
    }

    public static IEnumerator FreezePlayer(float seconds)
    {
        ArrowKeyMovement.playerRigidbody.velocity = Vector3.zero;
        ArrowKeyMovement.playerControl = false;
        yield return new WaitForSeconds(seconds);
        ArrowKeyMovement.playerControl = true;
    }

    public static Vector3 GetFacingVector()
    {
        Vector3 dir = Vector3.zero;
        switch (ArrowKeyMovement.getDirection())
        {
            case Facing.North:
                dir.y = 1f;
                break;
            case Facing.East:
                dir.x = 1f;
                break;
            case Facing.West:
                dir.x = -1f;
                break;
            default:
                dir.y = -1f;
                break;
        }
        return dir;
    }
}
