using DG.Tweening;
using TMPro;

namespace UI
{
    sealed class FadeText : DotweenUIEffect
    {
        private readonly TMP_Text _text;
        public FadeText(float fadeDuration, Ease easeType, TMP_Text text) : base(fadeDuration, easeType)
        {
            _text = text;
        }

        protected override Sequence CreateTweenActions(Ease easeType)
        {
            _text.alpha = 0f;
            _sequence.Append(_text.DOFade(1.0f, _effectDuration).SetEase(easeType));
            return _sequence;
        }
    }
}
