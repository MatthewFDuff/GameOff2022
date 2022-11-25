using Core.Modules.Controls.PlayerStateMachine;
using UnityEngine;

namespace Core.Modules.Controls
{
    // What controls our player. Mostly delegated to the state machine.
    public class PlayerController : MonoBehaviour
    {
        public PlayerStateMachineData data;
        PlayerStateMachine.PlayerStateMachine stateMachine;

        void Awake()
        {
            stateMachine = new PlayerStateMachine.PlayerStateMachine(this, data.DefaultState);
            data.machine = stateMachine;
        }

        public void Update()
        {
            stateMachine.CurrentState.OnUpdate(this);
        }
    }
}