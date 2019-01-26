using Sirenix.OdinInspector;
using UnityEngine;

public class DEV_Test_Doz : MonoBehaviour
{
    public Transform player;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            CameraFollow.Instance.ReplaceCamera(player.position, player.forward, 30f, 1f);

        }
    }
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

    [Button]
    public void ReplaceCamera(Vector3 position, Vector3 localEulerRotation, float fieldOfView, float duration)
    {
        CameraFollow.Instance.ReplaceCamera(position, localEulerRotation, fieldOfView, duration);
    }
}