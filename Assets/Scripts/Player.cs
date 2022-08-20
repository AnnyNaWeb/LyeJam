using UnityEngine;

namespace LyeJam
{
    public class Player : MonoBehaviour
    {
        [SerializeField] Projection _projection;
        [SerializeField] Vector3 _dirVel;

        private Plane _plane = new Plane(Vector3.up, 0);
        private Transform _transform;

        void Start()
        {
            _transform = this.gameObject.transform;
        }

        void Update()
        {
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (_plane.Raycast(ray, out distance))
            {
                Vector3 _worldPosition = ray.GetPoint(distance);
                var dist = (_transform.position - _worldPosition).normalized;
                dist = Vector3.Scale(dist, _dirVel);
                _projection.SimulateTrajectory(_transform.position, dist);
            }
            else
            {
                _projection.ClearTrajectory();
            }
        }
    }
}
