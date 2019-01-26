using Sirenix.OdinInspector;
using UnityEngine;

public class DEV_Test : MonoBehaviour
{
    [Button]
    public void IsPerpendicular2D(Side side, Side otherSide)
    {
        print(side.IsPerpendicular2D(otherSide));
    }
}