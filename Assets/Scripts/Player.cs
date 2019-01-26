using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _roof;

    [ShowInInspector, ReadOnly] private bool _isMoving;
    
    
    private Vector3 Position => transform.position + Vector3.down * MainVariables.Instance.GridWidth / 2;

    private Side RoofSide => transform.GetSideOf(_roof.transform, MainVariables.Instance.GridWidth / 2);

    [Button]
    private void Move(Side side)
    {
        if (_isMoving)
        {
            Debug.LogError("Player is already moving!");
            return;
        }
        var offset2D = side.ToVector();
        var farPoint = Position + (MainVariables.Instance.GridWidth / 2 * offset2D);

        var axis = (side == Side.North || side == Side.South) ? Vector3.left : Vector3.forward; 
        var rotationDirectionMultiplier = (side == Side.North || side == Side.East) ? -1 : 1;
        
        // Rotate
        var lastRotation = 0f;
        LeanTween.value(gameObject, 0, 90 * rotationDirectionMultiplier, 1).setOnUpdate((float f) =>
        {
            var rotation = f - lastRotation;
            transform.RotateAround(farPoint, axis, rotation);
            lastRotation = f;
        }).setOnStart(() => { _isMoving = true; }).setOnComplete(() => { _isMoving = false; });
    }

    private void CanMove(Side side)
    {
        if(RoofSide == side)
        {
            print("Can't move because of roof side!");
            return;
        }
        // 
        
        // Check if anything is in roofs way if move side and roof side is perpendicular
        if (side.IsPerpendicular2D(RoofSide))
        {
            
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
