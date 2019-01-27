using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject fpsPlayer;
    public Player homePlayer;

    private bool isFpsActive;

    void Start()
    {
        SwitchPlayer();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchPlayer();
        }
    }
    public void SwitchPlayer()
    {
        isFpsActive = !isFpsActive;

        if (isFpsActive)
        {
            homePlayer.enabled = false;
            StartCoroutine(FpsSetActiveRoutine(true, 1f));
            CameraFollow.Instance.ReplaceCamera(fpsPlayer.transform.position, fpsPlayer.transform.localEulerAngles, 57, 1f, false);

        }
        else
        {
            homePlayer.enabled = true;
            StartCoroutine(FpsSetActiveRoutine(false));
            CameraFollow.Instance.ReplaceCamera(CameraFollow.Instance.TargetPosition, CameraFollow.Instance.defaultRotation, 30, 1f, true);

        }

    }

    IEnumerator FpsSetActiveRoutine(bool isActivated, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        fpsPlayer.SetActive(isActivated);
        CameraFollow.Instance.mainCamera.enabled = !isActivated;
    }
}
