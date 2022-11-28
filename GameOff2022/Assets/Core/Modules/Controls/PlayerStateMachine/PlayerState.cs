using System;
using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    [Serializable]
    // Should we need access to another lifecycle method, put it in here.
    public abstract class PlayerState
    {
        public virtual void OnStateEnter(PlayerController controller){}
        public virtual void OnStateExit(PlayerController controller){}
        public virtual void OnUpdate(PlayerController controller){}
        public virtual void OnFixedUpdate(PlayerController controller){}
        public virtual void OnCollisionEnter(Collider otherCollider,PlayerController controller){}
    }
}