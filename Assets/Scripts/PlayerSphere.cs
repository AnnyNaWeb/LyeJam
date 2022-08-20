using UnityEngine;

namespace LyeJam
{
    public class PlayerSphere : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidBody;
        
        public bool IsGhost = false;

        public void Init(Vector3 velocity, bool isGhost = false)
        {
            IsGhost = isGhost;
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.AddForce(velocity, ForceMode.Impulse);
        }
    }
}
