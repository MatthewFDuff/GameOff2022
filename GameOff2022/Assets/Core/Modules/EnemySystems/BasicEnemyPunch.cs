using System;
using UnityEngine;

namespace Core.Scripts
{
    public class BasicEnemyPunch : EnemyAttack
    {
        [SerializeField] Collider2D punchCollider;
        [SerializeField] float windup;

        [SerializeField] float damageWindowInSeconds;
        
        public override void StartAttack()
        {
            Invoke(nameof(TriggerStart), windup);
        }

        void TriggerStart()
        {
            attackStarted?.Invoke();
            Invoke(nameof(EndAttack), damageWindowInSeconds);
        }

        public override void Attack(IDamageable damageable)
        {
            damageable.Damage(damage);
            EndAttack();
        }

        public override void EndAttack()
        {
            attackEnded?.Invoke();
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.TryGetComponent<IDamageable>(out var damageable)) return;
            
            Attack(damageable);
            EndAttack();
        }
    }
}