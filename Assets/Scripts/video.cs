using UnityEngine;
using UnityEngine.Video;

namespace LyeJam
{
    public class video : MonoBehaviour
    {
        public string url;
        VideoPlayer videoplayer;
        private float minutes;
        private float seconds;
        public GameObject gameplay, cutscene;

        void Start()
        {
            videoplayer = GetComponent<VideoPlayer>();
            cutscene.SetActive(true);
            gameplay.SetActive(false);
            videoplayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "cutscene.mp4");
            Play();
            videoplayer.loopPointReached += (_) => Pular();
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
