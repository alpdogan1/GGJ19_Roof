using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player homePlayer;
    [SerializeField] private GameObject fpsPlayer;
    [SerializeField] private HomeEnterDetector _homeEnterDetector;

    public Player HomePlayer => homePlayer;

    public GameObject FpsPlayer => fpsPlayer;

    [SerializeField] private bool isFpsActive;
    
    void Start()
    {
//        SwitchPlayer();
        HomePlayer.Initialize();

        HomePlayer.DidTriggerPiece += PlayerOnDidTriggerPiece;
        _homeEnterDetector.DidEnterHome += PlayerDidEnterHome;
        
        MasterAudio.PlaySound(SoundManager.Instance.Music1);
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

        GameBusyHandler.SetJob(true);
        
        if (isFpsActive)
        {
            homePlayer.enabled = false;
            StartCoroutine(FpsSetActiveRoutine(true, 1f));
            CameraFollow.Instance.ReplaceCamera(FpsPlayer.transform.position, FpsPlayer.transform.localEulerAngles, 57, 1f, false);

            MasterAudio.StopAllOfSound(SoundManager.Instance.Music2);
            MasterAudio.PlaySound(SoundManager.Instance.Music1);
            
        }
        else
        {
            homePlayer.enabled = true;
            StartCoroutine(FpsSetActiveRoutine(false));
            
            CameraFollow.Instance.mainCamera.transform.position = fpsPlayer.transform.position;
            CameraFollow.Instance.mainCamera.transform.rotation = fpsPlayer.transform.rotation;
            
            CameraFollow.Instance.ReplaceCamera(CameraFollow.Instance.TargetPosition, CameraFollow.Instance.defaultRotation, 30, 1f, true);
            
            MasterAudio.StopAllOfSound(SoundManager.Instance.Music1);
            MasterAudio.PlaySound(SoundManager.Instance.Music2);

        }
    }

    IEnumerator FpsSetActiveRoutine(bool isActivated, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        FpsPlayer.SetActive(isActivated);
        CameraFollow.Instance.mainCamera.enabled = !isActivated;
        LeanTween.delayedCall(1, () => { GameBusyHandler.SetJob(false); });
    }
    
    private void PlayerDidEnterHome()
    {
        if(!isFpsActive) return;
        
        SwitchPlayer();
    }

    private void PlayerOnDidTriggerPiece(Piece piece)
    {
        if(isFpsActive) return;

        if(piece.IsFinalTile) return;;
        
        FpsPlayer.transform.position = piece.TriggerFpsPosition.position;
        FpsPlayer.transform.rotation = piece.TriggerFpsPosition.rotation;
        FpsPlayer.GetComponent<FirstPersonController>().ReInitMouseLook();
        SwitchPlayer();

        // Duplicate home
        var oldHome = Instantiate(homePlayer);
        Destroy(oldHome.GetComponent<Player>());
        
        // Position home
        homePlayer.transform.position = piece.NextHomeTransformReference.position;
        homePlayer.transform.rotation = piece.NextHomeTransformReference.rotation;
    }
}
