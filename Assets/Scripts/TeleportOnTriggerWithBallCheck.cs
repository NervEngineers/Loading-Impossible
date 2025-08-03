using UnityEngine;

public class TeleportOnTriggerWithBallCheck : MonoBehaviour
{
    [SerializeField] private Transform locationA;
    [SerializeField] private Transform locationB;
    [SerializeField] private string teleportTag = "TeleportZone";

    public CollectLoading collectScript; // Drag and drop this in the Inspector

    private void Start()
    {
        if (locationA != null)
        {
            transform.position = locationA.position;
        }

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
                transform.position = locationB.position;
            }
            else
            {
                Debug.Log("You need at least 8 balls to teleport.");
            }
        }
    }
}