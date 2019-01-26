using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow> {

	public Camera mainCamera;
	public Transform cameraTransform;
	public GameObject cameraObject;
	public Transform followTarget;
	public Vector3 followOffset;

	private bool isFollowing;

	void LateUpdate()
	{
		if (isFollowing) {
			if (followTarget != null) {
			
				cameraTransform.position = followTarget.position + followOffset; 
			
			}
		
		}

	}

	public void TriggerFollow(bool isFollowing, Transform target=null)
	{
		this.isFollowing = isFollowing;

		if(target != null)
		{
			followTarget = target;
		}

	}
	public void ReplaceCamera(Vector3 position, Vector3 localEulerRotation, float fieldOfView, float duration)
	{
			TriggerFollow (false);

		LeanTween.move (cameraObject, position, duration).setEase (easeType: LeanTweenType.easeInOutQuart);
		LeanTween.rotateLocal (cameraObject, localEulerRotation, duration).setEase (easeType: LeanTweenType.easeOutQuart);
		LeanTween.value (mainCamera.fieldOfView, fieldOfView, duration).setOnUpdate((float val)=>{
			mainCamera.fieldOfView = val;
		});
	}

}
