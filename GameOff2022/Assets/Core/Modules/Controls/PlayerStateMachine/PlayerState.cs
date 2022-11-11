using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    // Should we need access to another lifecycle method, put it in here.
    public abstract class PlayerState
    {
        public virtual void OnStateEnter(PlayerStateMachineData data = null){}
        public virtual void OnStateExit(PlayerStateMachineData data = null){}
        public virtual void OnUpdate(PlayerStateMachineData data = null){}
        public virtual void OnCollisionEnter(Collider otherCollider,PlayerStateMachineData data = null){}
    }
}