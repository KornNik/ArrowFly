using UnityEngine;
using Spine.Unity;

namespace Behaviours
{
    sealed class ArcherAnimation : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private ArcherModel _model;

        [Header("Animations")]
        [SerializeField, SpineAnimation]
        private string _attackAnimation;
        [SerializeField, SpineAnimation]
        private string _begginAttackAnimation;
        [SerializeField, SpineAnimation]
        private string _endAttackAnimation;
        [SerializeField, SpineAnimation]
        private string _idleAnimation;
        [SerializeField, SpineAnimation]
        private string _attackDrawAnimation;
        [SerializeField, SpineEvent]
        private string _drawReleaseEvent;

        private AnimationEventHandler _animationEventHandler;

        private void Awake()
        {
            _animationEventHandler = new AnimationEventHandler(_model, _skeletonAnimation, _drawReleaseEvent);
            _skeletonAnimation.AnimationState.SetAnimation(0, _idleAnimation, true);
        }
        private void OnEnable()
        {
            _animationEventHandler.Subscribe();
        }
        private void OnDisable()
        {
            _animationEventHandler.Unsubscribe();
        }
        public void OnStartDraw()
        { 
            var shootTrack = _skeletonAnimation.AnimationState.SetAnimation(2, _begginAttackAnimation, false);
            shootTrack.AttachmentThreshold = 1f;
            shootTrack.MixDuration = 0f;
        }
        public void OnBowDraw()
        {

            var drawTrack = _skeletonAnimation.AnimationState.SetAnimation(1, _attackDrawAnimation, true);
            drawTrack.AttachmentThreshold = 1f;
            drawTrack.MixDuration = 0f;
        }
        public void OnDrawRelease()
        {
            var empty2 = _skeletonAnimation.state.AddEmptyAnimation(2, 0.5f, 0.1f);
            empty2.AttachmentThreshold = 1f;
            _skeletonAnimation.AnimationState.SetAnimation(1, _endAttackAnimation, false);
            _skeletonAnimation.AnimationState.AddAnimation(1, _idleAnimation, true,0);
        }
    }
}
