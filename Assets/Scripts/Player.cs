using UnityEngine;

namespace LyeJam
{
    public class Player : MonoBehaviour
    {
        [SerializeField] Projection _projection;
        [SerializeField] InputReader _input;

        [SerializeField] float _timeMax = 2;
        [SerializeField] float _forceMin = 1;
        [SerializeField] float _forceMax = 10;

        private Plane _plane = new Plane(Vector3.up, 0);
        private Transform _transform;

        void Start()
        {
            _transform = this.gameObject.transform;
            _input.Initialize();
            _input.OnDragEvent += UpdateProjection;
            _input.OnSwipeEvent += EndProjection;
        }

        void Update()
        {
            _input.Update();
        }

        void UpdateProjection(Vector2 mousePos, float timePassed)
        {
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            if (_plane.Raycast(ray, out distance))
            {
                Vector3 _worldPosition = ray.GetPoint(distance);
                var dist = (_transform.position - _worldPosition).normalized;

                dist *= Mathf.Max(_forceMin, (Mathf.Min(timePassed, _timeMax) / _timeMax) * _forceMax);

                _projection.SimulateTrajectory(_transform.position, dist);
            }
            else
            {
                _projection.ClearTrajectory();
            }
        }

        void EndProjection(Vector2 mousePos, float timePassed)
        {
            _projection.ClearTrajectory();
        }
    }
}
