using UnityEngine;
using UnityEngine.SceneManagement;

namespace LyeJam
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputReader _input;

        void Start()
        {
            _input.OnResetEvent += ResetScene;
        }

        void OnDestroy()
        {
            _input.OnResetEvent -= ResetScene;
        }

        void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
