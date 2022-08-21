using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LyeJam
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _playerPos;
        [SerializeField] private Transform _level_colisions;

        public Transform PlayerPos => _playerPos;
        public Transform Collisions => _level_colisions;

        void Start()
        {
        
        }
    }
}
