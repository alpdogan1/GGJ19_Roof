using System.Linq;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private Side[] _validRoofSides;

    public bool IsRoofSideValid(Side side)
    {
        return _validRoofSides.Contains(side);
    }
}