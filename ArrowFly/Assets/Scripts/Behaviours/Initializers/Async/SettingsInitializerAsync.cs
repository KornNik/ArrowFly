using Helpers;
using Controllers;
using Cysharp.Threading.Tasks;

namespace Behaviours
{
    sealed class SettingsInitializerAsync : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var settings = new SettingsController();
            Services.Instance.SettingsController.SetObject(settings);

            await UniTask.Yield();
        }
    }
}
