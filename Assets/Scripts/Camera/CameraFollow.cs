using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{

    public Camera mainCamera;
    public Transform cameraTransform;
    public GameObject cameraObject;
    public Transform followTarget;
    public Vector3 followOffset;

    private Vector3 TargetPosition
    {
        get
        {
            if (followTarget != null)
                return followTarget.position + followOffset;
            else
                return Vector3.zero;
        }
    }
    private bool isFollowing;
    private bool isReplacing;

    [SerializeField]
    private Vector3 defaultRotation;
    [SerializeField]
    private float defaultFoV;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ReplaceCamera(TargetPosition, defaultRotation, defaultFoV, 1f, true);

        }


    }
    void LateUpdate()
    {
        if (isFollowing)
        {
            if (followTarget != null)
            {

                cameraTransform.position = followTarget.position + followOffset;

            }
        }

    }

    public void TriggerFollow(bool isFollowing, Transform target = null)
    {
        this.isFollowing = isFollowing;

        if (target != null)
        {
            followTarget = target;
        }

    }
    public void ReplaceCamera(Vector3 position, Vector3 localEulerRotation, float fieldOfView, float duration, bool startFollowingAfterReplaced = false)
    {
        if (!isReplacing)
        {
            isReplacing = true;
            TriggerFollow(false);

            LeanTween.move(cameraObject, position, duration).setEase(easeType: LeanTweenType.easeInOutQuart);
            LeanTween.rotateLocal(cameraObject, localEulerRotation, duration * 2).setEase(easeType: LeanTweenType.easeOutQuart);
            LeanTween.value(mainCamera.fieldOfView, fieldOfView, duration).setOnUpdate((float val) =>
            {
                mainCamera.fieldOfView = val;
            }).setOnComplete(() =>
            {
                OnReplaced(true);
            });
        }
    }
    private void OnReplaced(bool startFollowingAfterReplaced)
    {
        isReplacing = false;
        if (startFollowingAfterReplaced)
        {
            TriggerFollow(true, followTarget);
        }
    }

}
