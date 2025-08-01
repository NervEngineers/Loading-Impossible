using System.Collections;
using TMPro;
using UnityEngine;

namespace ScriptUI
{
    public class MenuLoading : MonoBehaviour
    {
        public Animator anim;
        public TextMeshProUGUI percentage;
        private bool isShaking;
        public int percentageValue = 0;
        public int time = 0;
        public int speed = 0;

        void Update()
        {
            if (time > speed && percentageValue < 99)
            {
                percentageValue++;
                percentage.text = percentageValue.ToString() + "%";
                speed = Random.Range(1, 33);
                time = 0;
            }
            else if (percentageValue < 99)
            {
                time++;
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
                else if (hit != null && hit.gameObject == gameObject)
                {
                    StartCoroutine(DropLoadingAnimation());
                }
            }
        }

        IEnumerator ShakeAnimation()
        {
            anim.SetBool("Shake", true);
            isShaking = true;
            yield return new WaitForSeconds(1f);
            anim.SetBool("Shake", false);
            isShaking = false;
        }

        IEnumerator DropLoadingAnimation()
        {
            anim.SetBool("Drop", true);
            isShaking = true;
            percentage.text = "YOU RUINED IT";
            yield return new WaitForSeconds(6);
        }
    }
}