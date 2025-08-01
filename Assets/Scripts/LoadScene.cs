using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Name of the scene you want to load (set this in the Inspector)
    public string sceneName;

    // Call this method to load the scene
    public void OnEnable()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is empty. Please assign a scene name.");
        }
    }
}
