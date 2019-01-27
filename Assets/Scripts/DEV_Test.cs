using Sirenix.OdinInspector;
using UnityEngine;

public class DEV_Test : MonoBehaviour
{
    [Button]
    public void IsPerpendicular2D(Side side, Side otherSide)
    {
        print(side.IsPerpendicular2D(otherSide));
    }
    
    [Button]
    public void RotateSide(Side side, SideUtilities.SideRotationAxis axis, int direction)
    {
        print(side.Rotate(axis, direction));
    }
    [Button]
    public void RotateSideBySide(Side side, Side rotationSide)
    {
        print(side.Rotate(rotationSide));
    }
}