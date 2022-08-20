using UnityEngine.SceneManagement;
using UnityEngine;

namespace LyeJam
{
    public class Projection : MonoBehaviour
    {
        [SerializeField] private Transform _collisions;
        [SerializeField] private LineRenderer _line;
        [SerializeField] private PlayerSphere _playerPrefab;
        [SerializeField] private int _iterationMaxFrames = 100;

        private Scene _simulationScene;
        private PhysicsScene _physicsScene;
        private PlayerSphere _player;
        
        void Start()
        {
            CreatePhysicsScene(_playerPrefab);
        }
        
        void CreatePhysicsScene(PlayerSphere playerPrefab)
        {
            _simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
            _physicsScene = _simulationScene.GetPhysicsScene();

            foreach (Transform obj in _collisions)
            {
                var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
                ghostObj.GetComponent<Renderer>().enabled = false;
                SceneManager.MoveGameObjectToScene(ghostObj, _simulationScene);
            }
            
            _player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            _player.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(_player.gameObject, _simulationScene);
        }

        public void SimulateTrajectory(Vector3 pos, Vector3 velocity)
        {
            _player.transform.position = pos;
            _player.Init(velocity, true);
            _line.positionCount = _iterationMaxFrames;

            for (int i = 0; i < _iterationMaxFrames; i++)
            {
                _physicsScene.Simulate(Time.fixedDeltaTime);
                _line.SetPosition(i, _player.transform.position);
            }
        }

        public void ClearTrajectory()
        {
            _line.positionCount = 0;
        }
    }
}
