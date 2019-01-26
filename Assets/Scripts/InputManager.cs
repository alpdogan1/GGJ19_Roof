using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public event Action<Side> KeyPress;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            OnKeyPress(Side.North);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            OnKeyPress(Side.South);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            OnKeyPress(Side.West);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            OnKeyPress(Side.East);
    }

    protected virtual void OnKeyPress(Side side)
    {
        KeyPress?.Invoke(side);
    }
}
