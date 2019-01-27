using UnityEngine;

public class MainVariables : Singleton<MainVariables>
{
    public bool Dev_GodMode = false;
    public float GridWidth = 1f;
    public float PlayerRotationDuration = 0.3f;
    public LeanTweenType PlayerRotationEasing = LeanTweenType.easeOutQuad;
}