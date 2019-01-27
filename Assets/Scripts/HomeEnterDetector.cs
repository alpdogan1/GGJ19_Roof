using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class HomeEnterDetector : MonoBehaviour
{
    private BoxCollider _boxCollider;

    public BoxCollider BoxCollider
    {
        get
        {
            if (_boxCollider == null) _boxCollider = GetComponent<BoxCollider>();
            return _boxCollider;
        }
    }

    public event Action DidEnterHome;

    private void Update()
    {
        if (!GameBusyHandler.IsBusy &&
            GameManager.Instance.FpsPlayer.gameObject.activeInHierarchy &&
            BoxCollider.bounds.Contains(GameManager.Instance.FpsPlayer.transform.position))
        {
            print("HomeEnterDetector is triggered!");
            OnDidEnterHome();
        }
    }

    protected void OnDidEnterHome()
    {
        DidEnterHome?.Invoke();
    }
}