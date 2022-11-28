using System;
using Core.Scripts;
using UnityEngine;

namespace Core.Modules.Battle
{
    public class AttackHitbox : MonoBehaviour
    {
        [SerializeField] Collider2D hitbox;
        [SerializeField] int damage;
        [SerializeField] float impactForce;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!hitbox.enabled) return;
            if (!other.TryGetComponent<IDamageable>(out var damageable)) return;
            
            Debug.Log("Attacking " + other.gameObject);
            damageable.Damage(damage);
            var direction = (other.transform.position - transform.position).normalized ;
            other.attachedRigidbody.AddRelativeForce(direction * impactForce, ForceMode2D.Impulse);
        }
    }
}