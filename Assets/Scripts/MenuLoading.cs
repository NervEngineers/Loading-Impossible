using System.Collections;
using TMPro;
using UnityEngine;

public class MenuLoading : MonoBehaviour
{
    public Animator loadingAnim;
    public Animator cameraAnim;
    public TextMeshProUGUI percentage;
    private bool isShaking;
    public int percentageValue = 0;
    private float progressTimer = 0f;
    private float nextProgressTime = 0.1f;
    void Update()
    {
        if (percentageValue < 99)
        {
            progressTimer += Time.deltaTime;

            if (progressTimer >= nextProgressTime)
            {
                percentageValue++;
                percentage.text = percentageValue + "%";

                // Reset timer
                progressTimer = 0f;

                // Randomize next wait time between increments (makes it fast/slow randomly)
                nextProgressTime = Random.Range(0.01f, 0.20f);
            }
        }
            
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit == null || hit.gameObject != gameObject)
            {
                if (percentage.text == "99%" && isShaking == false)
                {
                    StartCoroutine(ShakeAnimation());
                }
            }
            else if (hit != null && hit.gameObject == gameObject && percentage.text == "99%")
            {
                StartCoroutine(DropLoadingAnimation());
            }
        }
    }

    IEnumerator ShakeAnimation()
    {
        loadingAnim.SetBool("Shake", true);
        isShaking = true;
        yield return new WaitForSeconds(1f);
        loadingAnim.SetBool("Shake", false);
        isShaking = false;
    }

    IEnumerator DropLoadingAnimation()
    {
        loadingAnim.SetBool("Drop", true);
        cameraAnim.SetBool("Down" , true);
        isShaking = true;
        percentage.text = "YOU RUINED IT";
        yield return new WaitForSeconds(6);
    }
}