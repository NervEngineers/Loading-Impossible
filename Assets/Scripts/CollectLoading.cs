using TMPro;
using UnityEngine;

public class CollectLoading : MonoBehaviour
{
    public int ball = 0;

    private Collider2D currentTrigger = null;
    public TextMeshProUGUI textMeshProUGUI;

    private void Update()
    {
        if (currentTrigger != null)
        {
            ball++;
            Debug.Log("Ball count: " + ball);
            textMeshProUGUI.text = ball.ToString() + "/8 Loading";

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
