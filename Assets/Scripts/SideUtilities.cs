using System;
using Sirenix.OdinInspector;
using UnityEngine;

public static class SideUtilities
{  
    [Button]
    public static bool IsPerpendicular2D(this Side side, Side otherSide)
    {
        if ((side == Side.North || side == Side.South) && (otherSide == Side.East || otherSide == Side.West)) return true;
        if ((otherSide == Side.North || otherSide == Side.South) && (side == Side.East || side == Side.West)) return true;
        return false;
    }

    public static Vector3 ToVector(this Side side)
    {
        switch (side)
        {
            case Side.North:
                return Vector3.forward;
            case Side.East:
                return Vector3.right;
            case Side.South:
                return Vector3.back;
            case Side.West:
                return Vector3.left;
            case Side.Top:
                return Vector3.up;
            case Side.Bottom:
                return Vector3.down;
            default:
                throw new ArgumentOutOfRangeException(nameof(side), side, null);
        }
    }

    public static Side GetSideOf(this Transform transform, Transform otherTransform, float threshold = float.Epsilon)
    {
        if (otherTransform.position.x - transform.position.x > threshold)
            return Side.East;
            
        if (otherTransform.position.x - transform.position.x < -threshold)
            return Side.West;
            
        if (otherTransform.position.y - transform.position.y > threshold)
            return Side.Top;
            
        if (otherTransform.position.y - transform.position.y < -threshold)
            return Side.Bottom;
            
        if (otherTransform.position.z - transform.position.z > threshold)
            return Side.North;
            
        if (otherTransform.position.z - transform.position.z < -threshold)
            return Side.South;

        Debug.LogError("Can't get side!");
        return Side.None;
    }
}