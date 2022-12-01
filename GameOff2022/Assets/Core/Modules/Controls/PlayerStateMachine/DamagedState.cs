using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    public class DamagedState : PlayerState
    {
        private static readonly int IsHurt = Animator.StringToHash("IsHurt");

        public override void OnStateEnter(PlayerController controller)
        {
            base.OnStateEnter(controller);
            
            controller.data.PlayerAnimator.SetBool(IsHurt ,true);
        }

        public override void OnStateExit(PlayerController controller)
        {
            controller.data.PlayerAnimator.SetBool(IsHurt ,false);
            base.OnStateExit(controller);
        }
    }
}