using UnityEngine;

namespace LyeJam
{
    public class Player : MonoBehaviour
    {
        public Projection _projection;
        [SerializeField] private InputReader _input;
        [SerializeField] private PlayerSphere _spherePrefab;

        [SerializeField] float _timeMax = 2;
        [SerializeField] float _forceMin = 1;
        [SerializeField] float _forceMax = 10;

        private Plane _plane = new Plane(Vector3.up, 0);
        private Transform _transform;
        private Renderer _renderer;
        private PlayerState _state = PlayerState.Idle;

        void Start()
        {
            _transform = this.gameObject.transform;
            _renderer = this.GetComponent<Renderer>();
            _input.Initialize();

            _input.OnDragEvent += UpdateProjection;
            _input.OnSwipeEvent += Launch;
        }

        void OnDestroy()
        {
            _input.OnDragEvent -= UpdateProjection;
            _input.OnSwipeEvent -= Launch;
        }

        void Update()
        {
            _input.Update();
        }

        void SetState(PlayerState value)
        {
            if (_state == value)
                return;
            
            switch (value)
            {
                case PlayerState.Idle: {
                    _renderer.material.SetColor("_Color", Color.white);
                } break;
                case PlayerState.Launching: {
                    _renderer.material.SetColor("_Color", Color.yellow);
                } break;
            }
            
            _state = value;
        }

        void UpdateProjection(Vector2 mousePos, float timePassed)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            if(MouseToPlayerDist(mousePos, timePassed) is {} dist)
            {
                SetState(PlayerState.Launching);
                _projection.SimulateTrajectory(_transform.position, dist);
            }
            else
            {
                SetState(PlayerState.Idle);
                _projection.ClearTrajectory();
            }
        }

        void Launch(Vector2 mousePos, float timePassed)
        {
            _projection.ClearTrajectory();
            _renderer.enabled = false;
            var sphere = Instantiate(_spherePrefab, _transform.position, Quaternion.identity, this.transform);

            if(MouseToPlayerDist(mousePos, timePassed) is {} dist)
            {
                sphere.Init(dist, false);
            }
        }   

        private Vector3? MouseToPlayerDist(Vector2 mousePos, float timePassed)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            if (_plane.Raycast(ray, out float distance))
            {
                Vector3 _worldPosition = ray.GetPoint(distance);
                Vector3 dist = (_transform.position - _worldPosition).normalized;
                dist *= Mathf.Max(_forceMin, (Mathf.Min(timePassed, _timeMax) / _timeMax) * _forceMax);

                return dist;
            }
            else
            {
                return null;
            }
        }
    }

    enum PlayerState
    {
        Idle,
        Launching
    }
}
