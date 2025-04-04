using Spine;
using Spine.Unity;


namespace Behaviours
{
    sealed class AnimationEventHandler : IEventSubscription
    {
        private ArcherModel _model;
        private string _drawReleaseEvent;
        private EventData _releaseEventData;
        private SkeletonAnimation _skeletonAnimation;

        public AnimationEventHandler(ArcherModel model, SkeletonAnimation skeletonAnimation, string drawReleaseEvent)
        {
            _model = model;
            _skeletonAnimation = skeletonAnimation;
            _drawReleaseEvent = drawReleaseEvent;
            _releaseEventData = _skeletonAnimation.skeleton.Data.FindEvent(_drawReleaseEvent);
        }

        public void Subscribe()
        {
            _skeletonAnimation.AnimationState.Event += HandleEvent;
        }

        public void Unsubscribe()
        {
            _skeletonAnimation.AnimationState.Event -= HandleEvent;
        }

        private void HandleEvent(TrackEntry trackEntry, Spine.Event e)
        {
            bool eventMatch = (_releaseEventData == e.Data);
            if (eventMatch)
            {
                _model.Combat.Attack();
            }
        }
    }
}
