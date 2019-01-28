using UnityEngine.SceneManagement;
using UnityEngine;

public class AnyKeySceneLoader : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("main");
        }
    }
}
