using UI;

namespace Behaviours
{
    internal class PauseState : BaseState
    {
        public PauseState(GameStateController stateController) : base(stateController)
        {

        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.PauseMenu);
        }

        public override void ExitState()
        {
        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
        }

        private void EndState()
        {
        }
    }
}