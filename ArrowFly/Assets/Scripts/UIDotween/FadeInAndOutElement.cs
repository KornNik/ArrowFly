using DG.Tweening;
using UnityEngine;
using Behaviours;
using System;

namespace UI
{
    sealed class FadeInAndOutElement : IDisposable
    {
        private DotweenUIEffect _fadeTween;
        private DotweenUIEffect _fadeReverseTween;

        public FadeInAndOutElement(float fadeDuration, Ease easeType, CanvasGroup fadeElement)
        {
            _fadeTween = new FadeElement(fadeDuration, easeType, fadeElement);
            _fadeReverseTween = new FadeElementReverse(fadeDuration, easeType, fadeElement);
        }

        public void Dispose()
        {
            _fadeTween.Dispose();
            _fadeReverseTween.Dispose();

            _fadeTween = null;
            _fadeReverseTween = null;
        }

        public void FadeWithType(MoveMode moveMode)
        {
            if (moveMode == MoveMode.Show)
            {
                _fadeTween.DoEffect();
            }
            else if (moveMode == MoveMode.Hide)
            {
                _fadeReverseTween.DoEffect();
            }
        }
    }
}
