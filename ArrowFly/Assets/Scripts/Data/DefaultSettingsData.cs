using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "SettingsData", menuName = "Data/Settings/SettingsData")]
    sealed class DefaultSettingsData : ScriptableObject
    {
        [SerializeField, Range(0, 4)] 
        private int _vsyncCount;
        [SerializeField,Range(25,300)] 
        private int _frameRate;
        [SerializeField] private bool _cursorVisibility;
        [SerializeField] private CursorLockMode _lockMode;

        public int VsyncCount => _vsyncCount;
        public int FrameRate => _frameRate;
        public bool CursorVisibility  => _cursorVisibility; 
        public CursorLockMode LockMode  => _lockMode;
    }
}
