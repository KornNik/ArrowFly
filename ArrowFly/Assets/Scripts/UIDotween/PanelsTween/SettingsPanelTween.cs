using UnityEngine;
using DG.Tweening;
using Data;

namespace Behaviours
{
    enum MoveMode
    {
        None = 0,
        Show = 1,
        Hide = 2

    }
    sealed class SettingsPanelTween
    {
        private readonly ScreenAnchors _screenAnchors;

        private readonly Ease _moveEase;
        private readonly RectTransform _moveRoot;
        private readonly float _totalMoveDuration;

        public SettingsPanelTween(RectTransform moveRoot, float totalMoveDuration, Ease moveEase, ScreenAnchors screenAnchors)
        {
            _moveRoot = moveRoot;
            _moveEase = moveEase;
            _totalMoveDuration = totalMoveDuration;
            _screenAnchors = screenAnchors;
        }

        public void GoToEnd(MoveMode mode)
        {
            switch (mode)
            {
                case MoveMode.Show:
                    _moveRoot.anchorMin = _screenAnchors.InAnchorMin;
                    _moveRoot.anchorMax = _screenAnchors.InAnchorMax;
                    break;
                case MoveMode.Hide:
                    _moveRoot.anchorMin = _screenAnchors.OutAnchorMin;
                    _moveRoot.anchorMax = _screenAnchors.OutAnchorMax;
                    break;
                default:
                    break;

            }
        }
        public Sequence Move(MoveMode mode, float timeScale)
        {
            Vector2 anchorMin = Vector2.zero;
            Vector2 anchorMax = Vector2.zero;

            switch (mode)
            {
                case MoveMode.Show:
                    anchorMin = _screenAnchors.InAnchorMin;
                    anchorMax = _screenAnchors.InAnchorMax;
                    break;
                case MoveMode.Hide:
                    anchorMin = _screenAnchors.OutAnchorMin;
                    anchorMax = _screenAnchors.OutAnchorMax;
                    break;
                default:
                    break;
            }

            return DOTween.Sequence()
                .Append(_moveRoot.DOAnchorMin(anchorMin, _totalMoveDuration * timeScale).SetEase(_moveEase))
                .Join(_moveRoot.DOAnchorMax(anchorMax, _totalMoveDuration * timeScale).SetEase(_moveEase));
        }
    }
}
