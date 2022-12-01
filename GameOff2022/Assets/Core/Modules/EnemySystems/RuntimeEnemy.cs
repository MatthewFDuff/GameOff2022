using System;
using Core.Modules.Battle;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Scripts
{
    public class RuntimeEnemy : MonoBehaviour, IDamageable
    {
        [SerializeField] Enemy enemy;
        [SerializeField] Animator animator;
        public UnityEvent<Enemy> death;
        static BattleManager manager;
        int health;
        private static readonly int IsHurt = Animator.StringToHash("IsHurt");

        public static event Action<int> OnEnemyDeath; 
        public static event Action OnEnemyNotHurt; 

        void Awake()
        {
            if (manager == null) manager = FindObjectOfType<BattleManager>();
        }

        public void Start()
        {
            if(enemy != null) Initialize(enemy);
            manager.AddEnemy(this);
        }

        public void Initialize(Enemy enemyGiven)
        {
            enemy = enemyGiven;
            health = enemy.MaxHealth;
        }
        
        public void Damage(int amount)
        {
            // More robust logic to come
            animator.SetBool(IsHurt, true);
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
            else
            {
                Invoke(nameof(ResetAnimation), 0.5f);
            }
        }

        private void ResetAnimation()
        {
            animator.SetBool(IsHurt, false);
        }

        private void Die()
        {
            OnEnemyDeath?.Invoke(enemy.scoreValue); // Sorry Brad. Time is of the essence.
            manager.RemoveEnemy(this);
            death?.Invoke(enemy);
        }

        public void Kill()
        {
            Destroy(gameObject, 0.5f);
        }
    }
}