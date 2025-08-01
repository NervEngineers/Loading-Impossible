using TMPro;
using UnityEngine;

namespace ScriptUI
{
    public class Percentage : MonoBehaviour
    {
        public TextMeshProUGUI percentage;
        public int percentageValue = 0;
        public int time = 0;
        public int speed = 0;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
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
        }
    }
}
