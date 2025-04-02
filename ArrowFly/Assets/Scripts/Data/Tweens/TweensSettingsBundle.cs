using Helpers.Extensions;
using UnityEngine;

namespace Data
{
    enum TweenSettingsType
    {
        None,
        ScreenDefaultSettings
    }
    enum ScreenAnchorsTweenType
    {
        None,
        TopToBottom,
        BottomToTop
    }

    [CreateAssetMenu(fileName = "TweenBundleData", menuName = "Data/Tween/TweenBundle")]
    sealed class TweensSettingsBundle : ScriptableObject
    {
        [SerializeField] private SerializableDictionary<TweenSettingsType, TweenSettings> _tweenSettings;
        [SerializeField] private SerializableDictionary<ScreenAnchorsTweenType, ScreenAnchorsSettings> _anchorsSettings;

        public TweenSettings GetTweenSettings(TweenSettingsType settingsType)
        {
            TweenSettings settings = null;
            if (_tweenSettings.Contains(settingsType))
            {
                settings = _tweenSettings[settingsType];
            }
            return settings;
        }
        public ScreenAnchorsSettings GetAnchorsSettings(ScreenAnchorsTweenType anchorsType)
        {
            ScreenAnchorsSettings settings = null;
            if (_anchorsSettings.Contains(anchorsType))
            {
                settings = _anchorsSettings[anchorsType];
            }
            return settings;
        }
    }
}
