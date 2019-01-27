using System;
using UnityEngine;

public class FPSPlayer_Alp : MonoBehaviour
{
    private event Action DidEnterHouse;

    
    
    
    protected virtual void OnDidEnterHome()
    {
        DidEnterHouse?.Invoke();
    }
}