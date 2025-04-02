using UnityEngine;
using DG.Tweening;

namespace UI
{
    sealed class BounceElement : DotweenUIEffect
    {
        private readonly Transform _elementTransform;
        private readonly float _effectIntensive;

        public BounceElement(float bounceDuration, Ease easeType, float bounceIntensive, Transform elementTransform) : base(bounceDuration, easeType)
        {
            _effectIntensive = bounceIntensive;
            _elementTransform = elementTransform;
        }

        protected override Sequence CreateTweenActions(Ease easeType)
        {
            _sequence.Append(_elementTransform.DOScale(_effectIntensive, _effectDuration / 2).SetEase(easeType));
            _sequence.Append(_elementTransform.DOScale(1f, _effectDuration / 2).SetEase(Ease.Linear));
            return _sequence;
        }
    }
}
