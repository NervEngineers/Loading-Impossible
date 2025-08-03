using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportOnTriggerWithBallCheck : MonoBehaviour
{
    [SerializeField] private Transform locationA;
    public string sceneName;
    [SerializeField] private string teleportTag = "TeleportZone";

    public CollectLoading collectScript; // Drag and drop this in the Inspector

    private void Start()
    {
        if (collectScript == null)
        {
            Debug.LogWarning("CollectLoading script not assigned!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(teleportTag) && collectScript != null)
        {
            if (collectScript.ball >= 8)
            {
                if (!string.IsNullOrEmpty(sceneName))
                {
                    SceneManager.LoadScene(sceneName);
                }
                else
                {
                    Debug.LogWarning("Scene name is empty. Please assign a scene name.");
                }            }
            else
            {
                Debug.Log("You need at least 8 balls to teleport.");
            }
        }
    }
}