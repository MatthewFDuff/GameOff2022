using System;
using UnityEngine;

namespace Core.Scripts
{
    public class RuntimeEnemy : MonoBehaviour, IDamageable
    {
        int health;

        public void Initialize(Enemy enemy)
        {
            health = enemy.MaxHealth;
        }
        
        public void Damage(int amount)
        {
            // More robust logic to come
            health -= amount;
        }
    }
}