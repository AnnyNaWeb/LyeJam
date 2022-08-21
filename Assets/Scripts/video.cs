using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace LyeJam
{
    public class video : MonoBehaviour
    {
       public string url;
        VideoPlayer videoplayer;
        public float totalTime;
        private float minutes;
        private static float seconds = 60;
        public GameObject gameplay, cutscene;
        bool pular;

        void Start()
        {
            videoplayer = GetComponent<VideoPlayer>();
            cutscene.SetActive(true);
            gameplay.SetActive(false);
            videoplayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "cutscene.mp4");
            pular = false;
             Play();
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
                TimerController.faseAtual = 1;
                gameplay.SetActive(true);
                Destroy(cutscene);
            }
            if (pular)
            {
                Pular();
            }
          
        }
        void Play()
        {
            
            videoplayer.Play();
            videoplayer.isLooping = false;
        }
        public void Pular()
        {
            TimerController.faseAtual = 1;
            gameplay.SetActive(true);
            Destroy(cutscene);
        }
    }
}
