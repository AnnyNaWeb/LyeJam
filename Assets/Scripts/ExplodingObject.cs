using System.Collections.Generic;
using UnityEngine;

namespace LyeJam
{
    public class ExplodingObject : MonoBehaviour
    {
        [SerializeField] private GameObject _parts;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Collider _collider;

        void OnCollisionEnter(Collision hit)
        {
            if(hit.transform.gameObject.tag == "Player")
            {
                var sphere = hit.transform.gameObject.GetComponent<PlayerSphere>();

                if(!sphere.IsGhost)
                {
                    TimerController.AddPoint();
                    _renderer.enabled = false;
                    _collider.enabled = false;
                    _parts.SetActive(true);
                }
            }
        }
    }
}
