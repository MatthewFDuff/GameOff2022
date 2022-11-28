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
        [SerializeField] Animator playerAnimator;
        public Rigidbody2D playerBody;
        public PlayerHealthScript health;

        public Animator PlayerAnimator => playerAnimator != null ? playerAnimator : null;

        [Header("States")]

        public DefaultState DefaultState;
        public WindUpAttackState lightAttackStateState;
        public WindUpAttackState heavyAttackStateState;

    }
}