using System;
using UnityEngine;


namespace Core.Modules.Controls.PlayerStateMachine
{
    // Anything we want the player statemachine to have access to should go here.
    [Serializable]
    public class PlayerStateMachineData
    {
        [Header("References")]
        public Transform transform;
        public Controls controls;
        [Header("Knobs")]
        public float Speed;

        public PlayerHealthScript health;
        public DefaultState DefaultState = new DefaultState();
        
    }
}