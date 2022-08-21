using UnityEngine.SceneManagement;
using UnityEngine;

namespace LyeJam
{
    public class Projection : MonoBehaviour
    {
        [SerializeField] private LineRenderer _line;
        [SerializeField] private PlayerSphere _playerPrefab;
        [SerializeField] private int _iterationMaxFrames = 100;

        private static Scene? _simulationScene = null;
        private static PhysicsScene _physicsScene;
        private PlayerSphere _player;
        
        public void StartProjection(Transform _collisions)
        {
            CreatePhysicsScene(_playerPrefab, _collisions);
        }
        
        void CreatePhysicsScene(PlayerSphere playerPrefab, Transform _collisions)
        {
            Scene scene;
            if(_simulationScene is {} _scn)
            {
                scene = _scn;
                foreach (var item in _simulationScene?.GetRootGameObjects())
                {
                    Destroy(item);
                }
            }
            else
            {
                scene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
                _physicsScene = scene.GetPhysicsScene();
                _simulationScene = scene;
            }

            foreach (Transform obj in _collisions)
            {
                var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
                ghostObj.GetComponent<Renderer>().enabled = false;
                SceneManager.MoveGameObjectToScene(ghostObj, scene);
            }
            
            _player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            _player.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(_player.gameObject, scene);
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
