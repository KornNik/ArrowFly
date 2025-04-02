using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    struct ScreenAnchors
    {
        public Vector2 InAnchorMin;
        public Vector2 InAnchorMax;
        [Space]
        public Vector2 OutAnchorMin;
        public Vector2 OutAnchorMax;
    }
    [CreateAssetMenu(fileName = "TweenAnchorsData", menuName = "Data/Tween/AnchorsSettings")]
    sealed class ScreenAnchorsSettings : ScriptableObject
    {
        [SerializeField] private ScreenAnchors _screenAnchors;

        public ScreenAnchors ScreenAnchors => _screenAnchors;
    }
}
