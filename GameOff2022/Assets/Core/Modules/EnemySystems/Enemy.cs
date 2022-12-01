using UnityEngine;

namespace Core.Scripts
{
    // An editor reference that provides a place to set the game data of any given enemy 
    [CreateAssetMenu(fileName = "newEnemy", menuName = "Scriptables/Enemy", order = 0)]
    public class Enemy : ScriptableObject
    {
        public GameObject EnemyPrefab => enemyPrefab;
        public int MaxHealth => maxHealth;
        
        [SerializeField] GameObject enemyPrefab;
        [SerializeField] int maxHealth;
        [SerializeField] private int scoreValue = 250;
    }
}