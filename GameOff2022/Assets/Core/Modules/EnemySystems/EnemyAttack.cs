using UnityEngine;
using UnityEngine.Events;

namespace Core.Scripts
{
    public abstract class EnemyAttack : MonoBehaviour
    {
        public UnityEvent attackStarted;
        public UnityEvent attackEnded;
        [SerializeField] protected int damage;
        public abstract void StartAttack();
        public abstract void Attack(IDamageable damageable);
        public abstract void EndAttack();
    }
}