namespace Behaviours
{
    internal class BaseState : IState
    {
        protected GameStateController _stateController;

        public BaseState(GameStateController stateController)
        {
            _stateController = stateController;
        }

        public virtual void EnterState()
        {
        }

        public virtual void ExitState()
        {
        }

        public virtual void LogicFixedUpdate()
        {
        }
        public virtual void LogicUpdate()
        {
        }
        public void LogicLateUpdate()
        {
        }
    }
}
