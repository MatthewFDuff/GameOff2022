using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    public class HeavyAttackState : PlayerState
    {
        private static readonly int IsPunching = Animator.StringToHash("IsPunching");

        public override void OnStateEnter(PlayerStateMachineData data = null)
        {
            base.OnStateEnter(data);
            
            data?.PlayerAnimator?.SetBool(IsPunching, true);
        }

        public override void OnStateExit(PlayerStateMachineData data = null)
        {
            base.OnStateExit(data);
            
            data?.PlayerAnimator?.SetBool(IsPunching, false);
        }
    }
}