using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LyeJam
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputReader _input;
        [SerializeField] private Canvas _pauseCanvas;
        [SerializeField] private Button _pauseButton;

        public bool isPaused = false;
        public static GameManager Instance;

        void Start()
        {
            GameManager.Instance = this;
            _input.OnResetEvent += ResetScene;
            _input.OnPauseEvent += PauseGame;
            _pauseButton.onClick.AddListener(PauseGame);
        }

        void OnDestroy()
        {
            _input.OnResetEvent -= ResetScene;
        }

        void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        void PauseGame()
        {
            if(!isPaused)
            {
                Time.timeScale = 0;
                _pauseCanvas.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                _pauseCanvas.gameObject.SetActive(false);
            }
            
            isPaused = !isPaused;
        }
    }
}
