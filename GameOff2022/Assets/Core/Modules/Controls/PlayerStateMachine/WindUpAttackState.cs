using System;
using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    [Serializable]
    public class WindUpAttackState : PlayerState
    {
        [SerializeField] float windupTime;
        [SerializeField] float attackLength;
        [SerializeField] float damage;
        [SerializeField] string animationName;
        [SerializeField] Collider2D attackCollider;
        [SerializeField] SpriteRenderer debugVisualizer;
        private int animation => Animator.StringToHash(animationName);
        Timer timer;
        PlayerController controller;

        public override void OnStateEnter(PlayerController controllerGiven)
        {
            base.OnStateEnter(controller);

            controller = controllerGiven;
            controller.data?.PlayerAnimator?.SetBool(animation, true);

            timer = new Timer(controller, windupTime);
            timer.OnCompleted += Attack;
            timer.Start();
        }

        public void Attack()
        {
            attackCollider.enabled = true;
            debugVisualizer.enabled = true;
            
            timer = new Timer(controller, attackLength);
            timer.OnCompleted += () => controller.data.machine.ChangeStateTo(controller.data.DefaultState);;
            timer.Start();
        }

        public override void OnStateExit(PlayerController controller)
        {
            base.OnStateExit(controller);
            
            timer.Stop();
            
            controller.data?.PlayerAnimator?.SetBool(animation, false);
            attackCollider.enabled = false;
            debugVisualizer.enabled = false;
        }
    }
}