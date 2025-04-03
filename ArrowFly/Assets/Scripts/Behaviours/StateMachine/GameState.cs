using Helpers;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState, IEventSubscription
    {
        private ArcherInputs _inputs;
        private ArcherController _controller;

        public GameState(GameStateController stateController) : base(stateController)
        {
            _inputs = new ArcherInputs();
        }

        public override void EnterState()
        {
            _controller = Services.Instance.Archer.ServicesObject;
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            Subscribe();
        }

        public override void ExitState()
        {
            Unsubscribe();
        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
            _inputs.UpdateInputs();
        }

        public void Subscribe()
        {
            _inputs.PerformDraw += _controller.Model.Animation.OnStartDraw;
            _inputs.InProgressDraw += _controller.Model.Animation.OnBowDraw;
            _inputs.ReleasDraw += _controller.Model.Animation.OnDrawRelease;

            _inputs.DrawDragValue += _controller.Model.Bow.OnHoldDraw;
            _inputs.ReleasDraw += _controller.Model.Bow.OnReleaseDraw;
            _inputs.PerformDraw += _controller.Model.Bow.OnStartDrawBow;
        }

        public void Unsubscribe()
        {
            _inputs.PerformDraw -= _controller.Model.Animation.OnStartDraw;
            _inputs.InProgressDraw -= _controller.Model.Animation.OnBowDraw;
            _inputs.ReleasDraw -= _controller.Model.Animation.OnDrawRelease;

            _inputs.DrawDragValue -= _controller.Model.Bow.OnHoldDraw;
            _inputs.ReleasDraw -= _controller.Model.Bow.OnReleaseDraw;
            _inputs.PerformDraw -= _controller.Model.Bow.OnStartDrawBow;
        }
    }
}
