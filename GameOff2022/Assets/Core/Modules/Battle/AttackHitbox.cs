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
            Debug.Log("Enemy Hit");
            if (!hitbox.enabled) return;
            if (!other.TryGetComponent<IDamageable>(out var damageable)) return;
            
            damageable.Damage(damage);
            var direction = (other.transform.position - transform.position).normalized ;
            other.attachedRigidbody.AddForce(direction * impactForce, ForceMode2D.Impulse);
        }
    }
}