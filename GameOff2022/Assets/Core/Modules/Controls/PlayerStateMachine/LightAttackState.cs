using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    public class LightAttackState : PlayerState
    {
        private static readonly int IsJabbing = Animator.StringToHash("IsJabbing");

        public override void OnStateEnter(PlayerStateMachineData data = null)
        {
            base.OnStateEnter(data);
            data?.playerAnimator.SetBool(IsJabbing, true);
        }

        public override void OnStateExit(PlayerStateMachineData data = null)
        {
            base.OnStateExit(data);
            data?.playerAnimator.SetBool(IsJabbing, false);
        }
    }
}