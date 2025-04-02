using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "TimeData", menuName = "Data/Settings/TimeData")]
    sealed class DefaultTimeData : ScriptableObject
    {
        [SerializeField, Range(0, 1)] private float _pauseTime = 0;
        [SerializeField, Range(0, 1)] private float _normalTime = 1f;

        public float PauseTime => _pauseTime;
        public float NormalTime => _normalTime;
    }
}
