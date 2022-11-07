using System;
using UnityEngine;

namespace Core.Scripts
{
    [Serializable]
    public class Wave
    {
        [SerializeField] Enemy[] enemiesInWave;
        public Enemy[] EnemiesInWave => enemiesInWave;
    }
}