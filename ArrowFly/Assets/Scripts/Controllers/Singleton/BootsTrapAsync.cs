using Helpers;
using Behaviours;
using Cysharp.Threading.Tasks;

namespace Controllers
{
    sealed class BootsTrapAsync : PersistanceSingleton<BootsTrapAsync>
    {
        private IInitializationAsync _systemsInitializer;
        private IInitializationAsync _componentsInitializer;

        private void Start()
        {
            InitializationComponents().Forget();
        }
        private async UniTaskVoid InitializationComponents()
        {
            _systemsInitializer = new SystemInitializerAsync();
            _componentsInitializer = new ComponentInitializerAsync();

            await _systemsInitializer.InitializationAsync();
            await _componentsInitializer.InitializationAsync();
        }
    }
}
