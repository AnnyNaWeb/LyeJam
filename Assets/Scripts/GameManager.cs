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
        [SerializeField] private GameObject _cutscene;
        [SerializeField] private TimerController _timer;

        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Level[] _leveis;

        [SerializeField] private GameObject _winScene;
        [SerializeField] private GameObject _loseScene;

        public bool isPaused = false;
        public static GameManager Instance;

        private Player _player;
        private Level _level;
        private int _currentScene = 0;

        void Start()
        {
            GameManager.Instance = this;
            _input.OnResetEvent += ResetScene;
            _input.OnPauseEvent += PauseGame;
            _pauseButton.onClick.AddListener(PauseGame);
            _cutscene.SetActive(true);

            _timer.OnWin += () =>
            {
                EndLevelMusic();
                _winScene.SetActive(true);
                isPaused = true;
            };
            
            _timer.OnLose += () => 
            {
                SoundPlayer.Instance.SetMusic(SoundPlayer.MusicEnum.derrota);
                _loseScene.SetActive(true);
            };
        }

        private void EndLevelMusic()
        {
            var music = _currentScene switch
            {
                0 => SoundPlayer.MusicEnum.endLevel1,
                1 => SoundPlayer.MusicEnum.endLevel2,
                2 => SoundPlayer.MusicEnum.endLevel3,
                _ => SoundPlayer.MusicEnum.endLevel4,
            };

            SoundPlayer.Instance.SetMusic(music);
        }

        public void NextLevel()
        {
            _currentScene += 1;
            isPaused = false;
            LoadLevel(_currentScene);
        }

        public void LoadLevel(int index)
        {
            _winScene.SetActive(false);
            _loseScene.SetActive(false);

            if(_leveis.Length > index)
            {
                SetMusic(index);
                _currentScene = index;

                if (_level != null)
                {
                    Destroy(_level.gameObject);
                }

                _level = Instantiate(_leveis[index], Vector3.zero, Quaternion.identity);
                _player = Instantiate(_playerPrefab, _level._playerPos.position, _level._playerPos.rotation, _level.transform);
                _player._projection.StartProjection(_level._level_colisions);
                _timer.StartTimer(_level.time, _level.destructionGoal);
            }
            else
            {
                Debug.Log("You win");
                Home();
            }
        }

        void SetMusic(int index)
        {
            var music = (index % 2) switch
            {
                < 4 => SoundPlayer.MusicEnum.ingame,
                _ => SoundPlayer.MusicEnum.ingameGlitch
            };

            SoundPlayer.Instance.SetMusic(music);
        }

        void OnDestroy()
        {
            _input.OnResetEvent -= ResetScene;
            _input.OnPauseEvent -= PauseGame;
        }

        public void ResetScene()
        {
            LoadLevel(_currentScene);
        }
        
        public void Home()
        {
            Projection.RemoveSimulation();
            SceneManager.LoadScene("Menu");
        }

        void PauseGame()
        {
            if(!isPaused)
            {
                Time.timeScale = 0;
                SoundPlayer.Instance.SetMusic(SoundPlayer.MusicEnum.pause);
                _pauseCanvas.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                SetMusic(_currentScene);
                _pauseCanvas.gameObject.SetActive(false);
            }
            
            isPaused = !isPaused;
        }
    }
}
