using DG.Tweening;
using System;
using System.Linq;

namespace Behaviours
{
    sealed class SequenceSettings : IDisposable
    {
        private Sequence _sequence;
        private SettingsPanelTween _panel;


        public SequenceSettings(SettingsPanelTween panel)
        {
            _panel = panel;
        }

        public void Dispose()
        {
            _sequence.Kill();
        }

        public Sequence Move(MoveMode mode)
        {
            float timeScale = 1.0f;

            if (_sequence != null)
            {
                timeScale = _sequence.position / _sequence.Duration();
                _sequence.Kill();
            }

            _sequence = DOTween.Sequence();
            _sequence.Join(_panel.Move(mode, timeScale));
            _sequence.AppendCallback(() =>
            {
                _sequence = null;

            });

            return _sequence;
        }
    }
}
