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
        private float seconds;
        public GameObject gameplay, cutscene;
        bool pular = false;

        void Start()
        {
            videoplayer = GetComponent<VideoPlayer>();
            cutscene.SetActive(true);
            gameplay.SetActive(false);
            videoplayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "cutscene.mp4");
            Play();
        }

        void Tempo()
        {
            totalTime += Time.deltaTime;
            minutes = (int)(totalTime / 60);
            seconds = (int)(totalTime % 60);
        }

        // Update is called once per frame
        void Update()
        {
            Tempo();
            if (totalTime >= 19 || pular)
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
            gameplay.SetActive(true);
            Destroy(cutscene);
            GameManager.Instance.LoadLevel(0);
        }
    }
}
