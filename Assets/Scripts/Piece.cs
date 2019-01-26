using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private Side[] _invalidRoofSides;

    public bool IsRoofSideValid(Side side)
    {
        return !_invalidRoofSides.Contains(side);
    }
    
    [Button]
    public void SetNormal()
    {
        _invalidRoofSides = new[] {Side.Bottom};
    }
    
    [Button]
    public void SetRoofTrigger()
    {
        _invalidRoofSides = new Side[0];
    }
}