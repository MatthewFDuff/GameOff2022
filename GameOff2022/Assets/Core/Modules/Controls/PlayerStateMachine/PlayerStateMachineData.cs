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
        public PlayerStateMachine machine;
        [Header("Knobs")]
        public float Speed;

        public PlayerHealthScript health;
        public DefaultState DefaultState = new DefaultState();
        public LightAttackState LightAttackState = new LightAttackState();
        public HeavyAttackState HeavyAttackState = new HeavyAttackState();
        
    }
}