using Helpers;
using Controllers;

namespace Behaviours
{
    class SettingsInitializer : IInitialization
    {
        public void Initialization()
        {
            var settings = new SettingsController();
            Services.Instance.SettingsController.SetObject(settings);
        }
    }
}
