using Sirenix.OdinInspector;
using UnityEngine;

public class DEV_Test_Doz : MonoBehaviour
{
    public Transform player;

    [Button]
    public void IsPerpendicular2D(Side side, Side otherSide)
    {
        print(side.IsPerpendicular2D(otherSide));
    }

    [Button]
    public void GiveTargetToCamera()
    {
        CameraFollow.Instance.TriggerFollow(true, player);
    }

}