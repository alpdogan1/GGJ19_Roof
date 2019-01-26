using Sirenix.OdinInspector;
using UnityEngine;

public class DEV_Test_Doz : MonoBehaviour
{
    [Button]
    public void IsPerpendicular2D(Side side, Side otherSide)
    {
        print(side.IsPerpendicular2D(otherSide));
    }

	[Button]
	public void GiveTargetToCamera(Transform target)
	{
		CameraFollow.Instance.TriggerFollow (true, target);
	}

	[Button]
	public void ReplaceCamera(Vector3 position, Vector3 localEulerRotation, float fieldOfView, float duration)
	{
		CameraFollow.Instance.ReplaceCamera (position,localEulerRotation,fieldOfView,duration);
	}
}