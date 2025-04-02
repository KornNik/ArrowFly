using Behaviours;
using Data;
using DG.Tweening;
using System;
using UnityEngine;

namespace UI
{
    sealed class DefaultScreenTweens : IDisposable
    {
        private SettingsPanelTween _panelTween;
        private SequenceSettings _sequenceSettings;
        private FadeInAndOutElement _tweenUIEffect;

        private GameObject _screenRefGameObject;

        public DefaultScreenTweens(RectTransform rectTransform, CanvasGroup canvasGroup,
            TweenSettings tweenSettings, ScreenAnchorsSettings anchorsSettings, GameObject screenGameObject)
        {
            _screenRefGameObject = screenGameObject;

            _panelTween = new SettingsPanelTween(rectTransform, tweenSettings.Duration, tweenSettings.EaseType,
                anchorsSettings.ScreenAnchors);
            _sequenceSettings = new SequenceSettings(_panelTween);
            _tweenUIEffect = new FadeInAndOutElement(tweenSettings.Duration, tweenSettings.EaseType, canvasGroup);
        }

        public void Dispose()
        {
            _tweenUIEffect.Dispose();
            _sequenceSettings.Dispose();

            _panelTween = null;
            _tweenUIEffect = null;
            _sequenceSettings = null;
        }

        public void Show()
        {
            _panelTween.GoToEnd(MoveMode.Hide);
            _sequenceSettings.Move(MoveMode.Show);
            _tweenUIEffect.FadeWithType(MoveMode.Show);
        }
        public void Hide()
        {
            _tweenUIEffect.FadeWithType(MoveMode.Hide);
            _sequenceSettings.Move(MoveMode.Hide).AppendCallback(() => _screenRefGameObject.SetActive(false));
        }
    }
}
