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
                Debug.Log("Light attack");
            }
            else if(Input.GetKeyDown(data.controls.heavyAttack))
            {
                Debug.Log("Heavy attack");
            }
        }
    }
}