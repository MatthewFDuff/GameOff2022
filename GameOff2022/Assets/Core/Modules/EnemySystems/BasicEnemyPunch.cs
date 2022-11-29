using System;
using UnityEngine;

namespace Core.Scripts
{
    public class BasicEnemyPunch : EnemyAttack
    {
        [SerializeField] float windup;
        [SerializeField] float damageWindowInSeconds;
        [SerializeField] float impactForce;
        bool isAttacking = false;
        Timer timer;
        public override void StartAttack()
        {
            if (isAttacking) return;
            isAttacking = true;
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
            isAttacking = false;
            attackEnded?.Invoke();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<IDamageable>(out var damageable)) return;
            Debug.Log("Attacking " + other.gameObject);
            var direction = (other.transform.position - transform.position).normalized ;
            other.attachedRigidbody.AddForce(direction * impactForce, ForceMode2D.Impulse);
            
            Attack(damageable);
            EndAttack();
        }
    }
}