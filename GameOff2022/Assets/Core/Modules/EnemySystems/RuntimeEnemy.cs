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
        public UnityEvent death;
        static BattleManager manager;
        int health;
        private static readonly int IsHurt = Animator.StringToHash("IsHurt");

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
            if(health <= 0) death?.Invoke();
            manager.RemoveEnemy(this);
            animator.SetBool(IsHurt, false);
        }

        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}