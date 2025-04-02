using UnityEngine;
using DG.Tweening;

namespace UI
{
    class FadeElementReverse : DotweenUIEffect
    {
        private readonly CanvasGroup _fadeElement;

        public FadeElementReverse(float fadeDuration, Ease easeType, CanvasGroup fadeElement) : base(fadeDuration, easeType)
        {
            _fadeElement = fadeElement;
        }
        protected override Sequence CreateTweenActions(Ease easeType)
        {
            _fadeElement.alpha = 1.0f;
            _sequence.Append(_fadeElement.DOFade(0.0f, _effectDuration).SetEase(easeType));
            return _sequence;
        }
    }
}