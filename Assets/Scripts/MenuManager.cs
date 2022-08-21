using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LyeJam
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _play_Button;
        [SerializeField] private Button _exit_Button;
      
        void Start()
        {
            _play_Button.onClick.AddListener(OnPlay);
            _exit_Button.onClick.AddListener(OnExit);
            SoundPlayer.Instance.SetMusic(SoundPlayer.MusicEnum.Menu);
        }

        void OnPlay()
        {
            TimerController.faseAtual = 1;
            SceneManager.LoadScene("MainScene");
        }
       
        void OnExit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
