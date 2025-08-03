using UnityEngine;

public class CollectLoading : MonoBehaviour
{
    public int ball = 0;

    private Collider2D currentTrigger = null;

    private void Update()
    {
        if (currentTrigger != null)
        {
            ball++;
            Debug.Log("Ball count: " + ball);

            Destroy(currentTrigger.gameObject);

            currentTrigger = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Loading"))
        {
            currentTrigger = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == currentTrigger)
        {
            currentTrigger = null;
        }
    }
}
