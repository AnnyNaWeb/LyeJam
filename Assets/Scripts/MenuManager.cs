using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LyeJam
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _play_Button;
        [SerializeField] private Button _exit_Button;

        [SerializeField] public float totalTime;
        [SerializeField] public Text tempo;

        private float minutes;
        private static float seconds = 60;

        void Start()
        {
            Text timer = gameObject.GetComponent<Timer>();
            _play_Button.onClick.AddListener(OnPlay);
            _exit_Button.onClick.AddListener(OnExit);
        }

        void OnPlay()
        {
            SceneManager.LoadScene("MainScene");
        }

        void OnExit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        void PlayTimer()
        {
            totalTime += Time.deltaTime;
            minutes = (int)(totalTime / 60);
            seconds = (int)(totalTime % 60);
            tempo.text = minutes.ToString() + " : " + seconds.ToString();
        }

        void Update()
        {
            PlayTimer();
        }
    }
}
