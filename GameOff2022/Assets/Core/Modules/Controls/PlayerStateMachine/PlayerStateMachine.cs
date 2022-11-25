namespace Core.Modules.Controls.PlayerStateMachine
{
    public class PlayerStateMachine
    {
        public PlayerState CurrentState { get; private set;}
        
        PlayerController controller;

        public PlayerStateMachine(PlayerController controller, PlayerState startingState)
        {
            this.controller = controller;
            ChangeStateTo(startingState);
        }

        public void ChangeStateTo(PlayerState newState)
        {
            CurrentState?.OnStateExit(controller);
            CurrentState = newState;
            CurrentState.OnStateEnter(controller);
        }
    }
}