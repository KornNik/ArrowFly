using UnityEngine;
using Spine;
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
        [SerializeField,SpineBone(dataField: "skeletonAnimation")]
        private string __targetIkBone;

        private EventData _releaseEventData;
        private Bone _targetBone;

        private void Awake()
        {
            _releaseEventData = _skeletonAnimation.skeleton.Data.FindEvent(_drawReleaseEvent);
            _skeletonAnimation.AnimationState.SetAnimation(0, _idleAnimation, true);
            _targetBone = _skeletonAnimation.Skeleton.FindBone(__targetIkBone);
        }
        private void OnEnable()
        {
            _skeletonAnimation.AnimationState.Event += HandleEvent;
        }
        private void OnDisable()
        {
            _skeletonAnimation.AnimationState.Event -= HandleEvent;
        }
        private void Update()
        {
            var skeletonSpacePointRight = _model.IkTargets.AimTarget.position;
            skeletonSpacePointRight.x *= _skeletonAnimation.Skeleton.ScaleX;
            skeletonSpacePointRight.y *= _skeletonAnimation.Skeleton.ScaleY;
            _targetBone.SetLocalPosition(skeletonSpacePointRight);
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

        private void HandleEvent(TrackEntry trackEntry, Spine.Event e)
        {
            bool eventMatch = (_releaseEventData == e.Data); // Performance recommendation: Match cached reference instead of string.
            if (eventMatch) 
            {
                _model.Combat.Attack();
            }
        }
    }
}
