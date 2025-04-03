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
        private string _rightHandIkBone;
        [SerializeField, SpineBone(dataField: "skeletonAnimation")]
        private string _leftHandIkBone;
        [SerializeField, SpineBone(dataField: "skeletonAnimation")]
        private string _chestIkBone;

        private EventData _releaseEventData;
        private Bone _rightHandBone;
        private Bone _leftHandBone;
        private Bone _chestBone;

        private void Awake()
        {
            _releaseEventData = _skeletonAnimation.skeleton.Data.FindEvent(_drawReleaseEvent);
            _skeletonAnimation.AnimationState.SetAnimation(0, _idleAnimation, true);
            _rightHandBone = _skeletonAnimation.Skeleton.FindBone(_rightHandIkBone);
            _leftHandBone = _skeletonAnimation.Skeleton.FindBone(_leftHandIkBone);
            _chestBone = _skeletonAnimation.Skeleton.FindBone(_chestIkBone);
        }
        private void OnEnable()
        {
            _skeletonAnimation.AnimationState.Event += HandleEvent;
        }
        private void OnDisable()
        {
            _skeletonAnimation.AnimationState.Event -= HandleEvent;
        }
        void Update()
        {
            var skeletonSpacePointRight = _skeletonAnimation.transform.InverseTransformPoint(_model.IkTargets.RightHand.position);
            skeletonSpacePointRight.x *= _skeletonAnimation.Skeleton.ScaleX;
            skeletonSpacePointRight.y *= _skeletonAnimation.Skeleton.ScaleY;
            _rightHandBone.SetLocalPosition(skeletonSpacePointRight);
            var skeletonSpacePointLeft = _skeletonAnimation.transform.InverseTransformPoint(_model.IkTargets.LeftHand.position);
            skeletonSpacePointLeft.x *= _skeletonAnimation.Skeleton.ScaleX;
            skeletonSpacePointLeft.y *= _skeletonAnimation.Skeleton.ScaleY;
            _leftHandBone.SetLocalPosition(skeletonSpacePointLeft);
            var skeletonSpacePointChest = _skeletonAnimation.transform.InverseTransformPoint(_model.IkTargets.ChestTarget.position);
            skeletonSpacePointChest.x *= _skeletonAnimation.Skeleton.ScaleX;
            skeletonSpacePointChest.y *= _skeletonAnimation.Skeleton.ScaleY;
            _chestBone.SetLocalPosition(skeletonSpacePointChest);
        }
        public void OnBowDraw()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _attackDrawAnimation, true);
        }
        public void OnStartDraw()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _begginAttackAnimation, false);
        }
        public void OnDrawRelease()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _endAttackAnimation, false);
            _skeletonAnimation.AnimationState.AddAnimation(0, _idleAnimation, true,0);
        }

        private void HandleEvent(TrackEntry trackEntry, Spine.Event e)
        {
            bool eventMatch = (_releaseEventData == e.Data); // Performance recommendation: Match cached reference instead of string.
            if (eventMatch) 
            {
                _model.Bow.ThrowArrow();
            }
        }
    }
}
