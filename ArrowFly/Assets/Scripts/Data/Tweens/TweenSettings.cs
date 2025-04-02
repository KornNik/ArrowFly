using DG.Tweening;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName ="TweenSettings",menuName ="Data/Tween/TweenSettings")]
    sealed class TweenSettings : ScriptableObject
    {
        [SerializeField] private float _duration;
        [SerializeField] private Ease _easeType;

        public Ease EaseType => _easeType;
        public float Duration => _duration;
    }
}
