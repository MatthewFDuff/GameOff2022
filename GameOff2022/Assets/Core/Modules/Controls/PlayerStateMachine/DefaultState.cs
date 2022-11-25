using System;
using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    [Serializable]
    public class DefaultState : MovementState
    {
        public override void OnUpdate(PlayerController controller)
        {
            if (controller.data == null) return;

            base.OnUpdate(controller);
            
            if (Input.GetKeyDown(controller.data.controls.lightAttack))
            {
                controller.data.machine.ChangeStateTo(controller.data.lightAttackStateState);
            }
            else if(Input.GetKeyDown(controller.data.controls.heavyAttack))
            {
                controller.data.machine.ChangeStateTo(controller.data.heavyAttackStateState);
            }
        }
    }
}