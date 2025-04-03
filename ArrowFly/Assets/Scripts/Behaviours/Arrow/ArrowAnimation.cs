using Spine.Unity;
using UnityEngine;

namespace Behaviours
{
    sealed class ArrowAnimation : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private ArrowTorque _arrow;

        [SpineAnimation]
        public string _exploedAnimation;
        [SpineAnimation]
        public string _idleAnimation;

        private void Awake()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _idleAnimation, true);
        }
        private void OnEnable()
        {
            _arrow.IsCollision += OnCollideExploed;
        }
        private void OnDisable()
        {
            _arrow.IsCollision -= OnCollideExploed;
        }

        private void OnCollideExploed()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _exploedAnimation, false);
            _skeletonAnimation.AnimationState.AddAnimation(0, _idleAnimation, true, 0f);
        }
    }
}
