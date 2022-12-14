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

        [SerializeField]
        private Animator _animator;
        private static readonly int IsPunching = Animator.StringToHash("IsPunching");

        public override void StartAttack()
        {
            if (isAttacking) return;
            isAttacking = true;
            _animator.SetBool(IsPunching, true);

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
            _animator.SetBool(IsPunching, false);
            attackEnded?.Invoke();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Triggered");
            if (!other.TryGetComponent<IDamageable>(out var damageable)) return;
            Debug.Log("Attacking " + other.gameObject);
            var direction = (other.transform.position - transform.position).normalized ;
            other.attachedRigidbody.AddForce(direction * impactForce, ForceMode2D.Impulse);
            
            Attack(damageable);
            EndAttack();
        }
    }
}