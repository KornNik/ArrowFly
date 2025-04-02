using Helpers;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        public GameState(GameStateController stateController) : base(stateController)
        {

        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
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
    }
}
