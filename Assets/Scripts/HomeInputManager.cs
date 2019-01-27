using System;
using UnityEngine;

public class HomeInputManager : Singleton<HomeInputManager>
{
    private const float Threshold = .1f;
    
    public event Action<Side> KeyPress;

    
    private void Update()
    {
        if(!GameManager.Instance.HomePlayer.enabled || GameBusyHandler.IsBusy) return;
        
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical") > Threshold)
            OnKeyPress(Side.North);
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical") < -Threshold)
            OnKeyPress(Side.South);
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < -Threshold)
            OnKeyPress(Side.West);
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > Threshold)
            OnKeyPress(Side.East);
    }

    protected virtual void OnKeyPress(Side side)
    {
        KeyPress?.Invoke(side);
    }
}
