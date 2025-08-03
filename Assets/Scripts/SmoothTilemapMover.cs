using UnityEngine;
using UnityEngine.Tilemaps;

public class SmoothTilemapMover : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector2 startOffset;     // Local offset from initial position
    public Vector2 endOffset;       // Local offset from initial position
    public float moveDuration = 2f;

    private Vector3 startPos;
    private Vector3 endPos;
    private float elapsedTime;
    private bool movingToEnd = true;

    void Start()
    {
        if (tilemap != null)
        {
            Vector3 basePos = tilemap.transform.position;
            startPos = basePos + (Vector3)startOffset;
            endPos = basePos + (Vector3)endOffset;
            tilemap.transform.position = startPos;
        }
    }

    void Update()
    {
        if (tilemap == null) return;

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / moveDuration);

        if (movingToEnd)
        {
            tilemap.transform.position = Vector3.Lerp(startPos, endPos, t);
        }
        else
        {
            tilemap.transform.position = Vector3.Lerp(endPos, startPos, t);
        }

        if (t >= 1f)
        {
            movingToEnd = !movingToEnd;    // Reverse direction
            elapsedTime = 0f;              // Reset timer
        }
    }
}
