using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LyeJam
{
    public class video : MonoBehaviour
    {
        public float totalTime;
        private float minutes;
        private static float seconds = 60;
        public GameObject gameplay, cutscene;

        void Start()
        {
            cutscene.SetActive(true);
            gameplay.SetActive(false);
        }
        void Tempo()
        {
           
                totalTime += Time.deltaTime;
                minutes = (int)(totalTime / 60);
                seconds = (int)(totalTime % 60);
                //tempo.text = minutes.ToString() + " : " + seconds.ToString();

              
            
        }

        // Update is called once per frame
        void Update()
            
        {
            Tempo();
            if (totalTime >= 19)
            {
                gameplay.SetActive(true);
                Destroy(cutscene);
            }
        }
    }
}
