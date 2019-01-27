using UnityEngine;

public class GameManager_Alp : Singleton<GameManager_Alp>
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _fpsPlayer;
    [SerializeField] private HomeEnterDetector _homeEnterDetector;

    public Player Player => _player;

    private void Start()
    {
        Player.DidTriggerPiece += PlayerOnDidTriggerPiece;
        _homeEnterDetector.DidEnterHome += PlayerDidEnterHome;
    }

    private void PlayerDidEnterHome()
    {
        // Switch code
        
        
    }

    private void PlayerOnDidTriggerPiece(Piece piece)
    {
        // Switch code

        _fpsPlayer.transform.position = piece.TriggerFpsPosition.position;
    }
    
    
}