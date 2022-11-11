namespace Core.Modules.Controls.PlayerStateMachine
{
    public class PlayerStateMachine
    {
        public PlayerState CurrentState { get; private set;}
        
        PlayerStateMachineData data;

        public PlayerStateMachine(PlayerStateMachineData dataGiven, PlayerState startingState)
        {
            data = dataGiven;
            ChangeStateTo(startingState);
        }

        public void ChangeStateTo(PlayerState newState)
        {
            CurrentState?.OnStateExit(data);
            CurrentState = newState;
            CurrentState.OnStateEnter(data);
        }
    }
}