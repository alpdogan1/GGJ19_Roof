using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Piece : MonoBehaviour
{
    [SerializeField] private Side[] _invalidRoofSides;
    [SerializeField] private bool _isTrigger;
    [SerializeField] private UnityEvent _didTrigger;
    [SerializeField] private Transform _triggerFpsPosition;
    [SerializeField] private Transform _nextHomeTransformReference;
    [SerializeField] public bool IsFinalTile;

    public bool IsTrigger => _isTrigger;

    public Transform TriggerFpsPosition => _triggerFpsPosition;

    public Transform NextHomeTransformReference => _nextHomeTransformReference;

    public bool IsRoofSideValid(Side side)
    {
        return !_invalidRoofSides.Contains(side);
    }
    
    [Button]
    public void SetNormal()
    {
        _invalidRoofSides = new[] {Side.Bottom};
        _isTrigger = false;
    }
    
    [Button]
    public void SetRoofTrigger()
    {
        _invalidRoofSides = new Side[0];
        _isTrigger = true;
    }

    [Button]
    public void Trigger()
    {
        _didTrigger.Invoke();
    }
}