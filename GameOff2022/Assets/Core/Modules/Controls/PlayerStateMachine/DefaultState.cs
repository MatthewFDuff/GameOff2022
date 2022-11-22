using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    public class DefaultState : MovementState
    {
        public override void OnUpdate(PlayerStateMachineData data = null)
        {
            if (data == null) return;

            base.OnUpdate(data);
            
            if (Input.GetKeyDown(data.controls.lightAttack))
            {
                data.machine.ChangeStateTo(data.LightAttackState);
            }
            else if(Input.GetKeyDown(data.controls.heavyAttack))
            {
                data.machine.ChangeStateTo(data.HeavyAttackState);
            }
        }
    }
}