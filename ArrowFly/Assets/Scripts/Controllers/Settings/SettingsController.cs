using Behaviours;
using UnityEngine;
using Data;
using Helpers;

namespace Controllers
{
    class SettingsController : ISettingsController
    {
        private DefaultSettingsData _settingsData;

        public SettingsController()
        {
            _settingsData = Services.Instance.DatasBundle.ServicesObject.GetData<DefaultSettingsData>();
            LockedFPS();
        }
        public void LockedFPS()
        {
            QualitySettings.vSyncCount = _settingsData.VsyncCount;
            Application.targetFrameRate = _settingsData.FrameRate;
        }
        public void LockedCursor()
        {
            Cursor.lockState = _settingsData.LockMode;
            Cursor.visible = _settingsData.CursorVisibility;
        }
        public void UnLockedCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
