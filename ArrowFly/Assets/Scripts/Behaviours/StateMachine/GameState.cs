using Helpers;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private ArcherInputs _inputs;
        private ArcherController _controller;
        private SetupInputsActions _setupInputsActions;

        public GameState(GameStateController stateController) : base(stateController)
        {
            _inputs = new ArcherInputs();
        }

        public override void EnterState()
        {
            _controller = Services.Instance.Archer.ServicesObject;
            _setupInputsActions = new SetupInputsActions(_inputs, _controller);
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            _setupInputsActions.Subscribe();
        }

        public override void ExitState()
        {
            _setupInputsActions.Unsubscribe();
        }

        public override void LogicFixedUpdate()
        {

        }

        public override void LogicUpdate()
        {
            _inputs.UpdateInputs();
        }
    }
}
