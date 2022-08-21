using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LyeJam
{
    public class TimerController : MonoBehaviour
    {
        public float totalTime;
        public Text tempo;

        private float minutes;
        private static float seconds = 60;
        void PlayLevel ()
        {
            totalTime += Time.deltaTime;
            minutes = (int)(totalTime / 60);
            seconds = (int)(totalTime % 60);
            tempo.text = minutes.ToString() + " : " + seconds.ToString();
        }

        
        void Update()
        {
            PlayLevel();
        }
    }
}
