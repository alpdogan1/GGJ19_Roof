using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class HomeEnterDetector : MonoBehaviour
{
    private Bounds _bounds;

    public event Action DidEnterHome;

    private void Start()
    {
        _bounds = GetComponent<Collider>().bounds;
    }

    private void Update()
    {


        if (_bounds.Contains(GameManager_Alp.Instance.Player.transform.position))
        {
            OnDidEnterHome();
        }
    }

    protected void OnDidEnterHome()
    {
        DidEnterHome?.Invoke();
    }
}