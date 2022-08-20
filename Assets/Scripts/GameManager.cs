using UnityEngine;
using UnityEngine.SceneManagement;

namespace LyeJam
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputReader _input;

        private bool isPaused = false;

        void Start()
        {
            _input.OnResetEvent += ResetScene;
            _input.OnPauseEvent += PauseGame;
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
            }
            else
            {
                Time.timeScale = 1;
            }
            
            isPaused = !isPaused;
        }
    }
}
