using UnityEngine;
using UnityEngine.Events;

namespace Core.Scripts
{
    public class RuntimeEnemy : MonoBehaviour, IDamageable
    {
        [SerializeField] Enemy enemy;
        [SerializeField] Animator animator;
        public UnityEvent death;
        int health;

        public void Initialize(Enemy enemyGiven)
        {
            enemy = enemyGiven;
            health = enemy.MaxHealth;
        }
        
        public void Damage(int amount)
        {
            // More robust logic to come
            health -= amount;
            if(health <= 0) death?.Invoke();
            //animator.SetBool();
        }
    }
}