using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class CanvasManager : Singleton<CanvasManager>
{
    public CanvasGroup messageGroup;
    public Text messageBox;
    private RectTransform messageTransform;

    private Coroutine messageRoutine;
    private Coroutine writeRoutine;

    void Awake()
    {
        messageTransform = messageBox.rectTransform;
    }
    public void ShowMessage(string messageText, float duration)
    {
        if (messageRoutine != null)
        {
            StopCoroutine(messageRoutine);
            StopCoroutine(writeRoutine);

            LeanTween.cancel(gameObject);
            //            LeanTween.alphaCanvas(messageGroup.transform, 0, 0);
            //            LeanTween.alphaCanvas(messageGroup, 0, 0);
            messageGroup.alpha = 0;

            // LeanTween.alphaText
            // var ltId = LeanTween.Move(gameObject, ).id;
        }

        messageRoutine = StartCoroutine(MessageRoutine(messageText, duration));
    }

    IEnumerator MessageRoutine(string messageText, float duration)
    {
        float fadeDuration = 0.3f;
        writeRoutine = StartCoroutine(WriteAnimation(messageText));
        LeanTween.alphaCanvas(messageGroup, 1, fadeDuration).setEase(LeanTweenType.easeOutCirc);
        yield return new WaitForSeconds(duration - (fadeDuration * 2));
        LeanTween.alphaCanvas(messageGroup, 0, fadeDuration).setEase(LeanTweenType.easeInCirc);
        yield return new WaitForSeconds(fadeDuration);
        messageRoutine = null;
    }
    IEnumerator WriteAnimation(string message)
    {
        int i = 0;
        string str = "";
        while (i < message.Length)
        {
            str += message[i++];
            messageBox.text = str;
            // yield return new WaitForFrames
            yield return new WaitForSeconds(0.01F);
        }
    }
    [Button]
    public void RestartClicked()
    {
        SceneManager.LoadScene("intro");
    }
    public void ExitClicked()
    {
        Application.Quit();
    }
}
