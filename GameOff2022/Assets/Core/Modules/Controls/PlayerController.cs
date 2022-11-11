using System;
using Core.Modules.Controls.PlayerStateMachine;
using UnityEngine;

namespace Core.Modules.Controls
{
    // What controls our player. Mostly delegated to the state machine.
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerStateMachineData data;
        PlayerStateMachine.PlayerStateMachine stateMachine;

        void Awake()
        {
            stateMachine = new PlayerStateMachine.PlayerStateMachine(data, data.MovementState);
        }

        public void Update()
        {
            stateMachine.CurrentState.OnUpdate();
        }
    }
}