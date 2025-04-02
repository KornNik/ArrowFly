using DG.Tweening;
using System;

namespace UI
{
    abstract class DotweenUIEffect : IDisposable
    {
        protected readonly float _effectDuration;
        protected readonly Ease _easeType;

        protected Sequence _sequence;

        public DotweenUIEffect(float effectDuration, Ease easeType)
        {
            _easeType = easeType;
            _effectDuration = effectDuration;
        }
        public void Dispose()
        {
            _sequence.Kill(true);
           _sequence = null;
        }

        public virtual void DoEffect()
        {
            _sequence = DOTween.Sequence();
            CreateTweenActions(_easeType);
        }
        public virtual void DoEffect(Action actionOnComplete)
        {
            _sequence = DOTween.Sequence();
            CreateTweenActions(_easeType).OnComplete(() => actionOnComplete.Invoke());
        }
        protected abstract Sequence CreateTweenActions(Ease easeType);
    }
}

