using UnityEngine;

public static class GameBusyHandler
{
    private static int _jobCount = 0;

    public static bool IsBusy => _jobCount > 0;

    public static void SetJob(bool isStart)
    {
        if (isStart)
        {
            _jobCount++;
        }
        else
        {
            LeanTween.delayedCall(.1f, () => { _jobCount--; });
        }
    }
}