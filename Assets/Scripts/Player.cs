using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _roof;

    [ShowInInspector, ReadOnly] private bool _isMoving;
    
    private Vector3 Position => transform.position + Vector3.down * MainVariables.Instance.GridWidth / 2;

    private Side RoofSide => transform.GetSideOf(_roof.transform, MainVariables.Instance.GridWidth / 4);

    private void Start()
    {
        InputManager.Instance.KeyPress += OnKeyPress;
    }

    private void OnKeyPress(Side side)
    {
        Move(side);
    }

    [Button]
    private void Move(Side side)
    {
        if (_isMoving)
        {
            Debug.LogError("Player is already moving!");
            return;
        }
        
        if (!CanMove(side)) return;
        
        var offset2D = side.ToVector();
        var farPoint = Position + (MainVariables.Instance.GridWidth / 2 * offset2D);

        var axis = (side == Side.North || side == Side.South) ? Vector3.left : Vector3.forward; 
        var rotationDirectionMultiplier = (side == Side.North || side == Side.East) ? -1 : 1;
        
        // Rotate
        var lastRotation = 0f;
        LeanTween.value(gameObject, 0, 90 * rotationDirectionMultiplier, MainVariables.Instance.PlayerRotationDuration)
            .setEase(MainVariables.Instance.PlayerRotationEasing)
            .setOnUpdate((float f) =>
        {
            var rotation = f - lastRotation;
            transform.RotateAround(farPoint, axis, rotation);
            lastRotation = f;
        })
            .setOnStart(() => { _isMoving = true; })
            .setOnComplete(() => { _isMoving = false; });
    }

    private bool CanMove(Side side)
    {
        var nextPiece = GetPieceBySide(side);

        if (!nextPiece)
        {
            print("Can't move because no piece there!");
            return false;
        }

        var nextRoofSide = RoofSide.Rotate(side);

        if (!nextPiece.IsRoofSideValid(nextRoofSide))
        {
            print($"Can't move to {side}, next tile doesn't allow roof side of {nextRoofSide}");
            return false;
        }

        return true;

//        if(RoofSide == side)
//        {
//            print("Can't move because of roof side!");
//            return;
//        }

        // Check if anything is in roofs way if move side and roof side is perpendicular
//        if (side.IsPerpendicular2D(RoofSide))
//        {
//            
//        }
    }

    [Button]
    private Piece GetPieceBySide(Side side)
    {
        var raycastOffset = side.ToVector() * MainVariables.Instance.GridWidth;
        var raycastPos = transform.position + raycastOffset;
        
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(raycastPos, Vector3.down, out hit))
        {
            Debug.DrawRay(raycastPos, Vector3.down * hit.distance, Color.green, 5);
            Debug.Log("Did Hit");
            return hit.transform.GetComponent<Piece>();
        }
        else
        {
            Debug.DrawRay(raycastPos, Vector3.down * 50, Color.red, 5);
            Debug.Log("Did not Hit");
            return null;
        }
    }
    
    #if UNITY_EDITOR
    [Button]
    private void TestRoofSide()
    {
        print(RoofSide);
    }
    #endif
}
