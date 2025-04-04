namespace Behaviours
{
    sealed class SetupInputsActions : IEventSubscription
    {
        private ArcherInputs _inputs;
        private ArcherController _controller;

        public SetupInputsActions(ArcherInputs inputs, ArcherController controller)
        {
            _inputs = inputs;
            _controller = controller;
        }

        public void Subscribe()
        {
            _controller.Model.Combat.Actions.StartDraw += _controller.Model.Animation.OnStartDraw;
            _controller.Model.Combat.Actions.HoldDraw += _controller.Model.Animation.OnBowDraw;
            _controller.Model.Combat.Actions.EndDraw += _controller.Model.Animation.OnDrawRelease;

            _inputs.DrawDragValue += _controller.Model.Combat.OnHoldDraw;
            _inputs.ReleasDraw += _controller.Model.Combat.OnReleaseDraw;
            _inputs.PerformDraw += _controller.Model.Combat.OnStartDrawBow;
        }

        public void Unsubscribe()
        {
            _controller.Model.Combat.Actions.StartDraw -= _controller.Model.Animation.OnStartDraw;
            _controller.Model.Combat.Actions.HoldDraw -= _controller.Model.Animation.OnBowDraw;
            _controller.Model.Combat.Actions.EndDraw -= _controller.Model.Animation.OnDrawRelease;

            _inputs.DrawDragValue += _controller.Model.Combat.OnHoldDraw;
            _inputs.ReleasDraw += _controller.Model.Combat.OnReleaseDraw;
            _inputs.PerformDraw += _controller.Model.Combat.OnStartDrawBow;
        }
    }
}
