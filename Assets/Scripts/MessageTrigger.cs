using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MessageTrigger : MonoBehaviour
{
       [TextArea(15,20)]
    public string text;
    public float duration;

    private bool isTriggered;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (!isTriggered)
            {
                TriggerMessage();
            }
        }

    }

    [Button]
    public void TriggerMessage()
    {
        isTriggered = true;
        CanvasManager.Instance.ShowMessage(text, duration);

    }
}
