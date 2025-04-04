using Spine.Unity;
using UnityEngine;

namespace Behaviours
{
    sealed class ArrowAnimation : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private Arrow _arrow;

        [SpineAnimation]
        public string _exploedAnimation;
        [SpineAnimation]
        public string _idleAnimation;

        private void OnEnable()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _idleAnimation, true);
            _arrow.IsCollision += OnCollideExploed;
        }
        private void OnDisable()
        {
            _arrow.IsCollision -= OnCollideExploed;
        }

        private void OnCollideExploed()
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, _exploedAnimation, false);
        }
    }
}
