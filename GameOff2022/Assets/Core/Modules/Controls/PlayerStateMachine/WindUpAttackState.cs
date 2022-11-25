using System;
using UnityEditor.UI;
using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    [Serializable]
    public class WindUpAttackState : PlayerState
    {
        [SerializeField] float windupTime;
        [SerializeField] float damage;
        [SerializeField] string animationName;
        [SerializeField] Collider2D attackCollider;
        private int animation => Animator.StringToHash(animationName);

        public override void OnStateEnter(PlayerController controller)
        {
            base.OnStateEnter(controller);
            controller.data?.PlayerAnimator?.SetBool(animation, true);
            
            controller.Invoke(nameof(Attack), windupTime);
        }

        public void Attack()
        {
            attackCollider.enabled = true;
        }

        public override void OnStateExit(PlayerController controller)
        {
            base.OnStateExit(controller);
            controller.data?.PlayerAnimator?.SetBool(animation, false);
            attackCollider.enabled = false;
        }
    }
}