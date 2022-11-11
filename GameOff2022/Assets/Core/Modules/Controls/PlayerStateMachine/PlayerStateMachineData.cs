using System;
using UnityEngine;

namespace Core.Modules.Controls.PlayerStateMachine
{
    // Anything we want the player statemachine to have access to should go here.
    [Serializable]
    public class PlayerStateMachineData
    {
        public Transform transform;
        public float Speed;
        public Controls controls;
        public MovementState MovementState = new MovementState();
    }
}