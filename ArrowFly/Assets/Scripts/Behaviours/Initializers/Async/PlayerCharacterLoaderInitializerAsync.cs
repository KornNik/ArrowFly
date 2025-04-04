using Cysharp.Threading.Tasks;
using Helpers;

namespace Behaviours
{
    sealed class PlayerCharacterLoaderInitializerAsync : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var characterLoader = new PlayerCharacterLoader();
            Services.Instance.PlayerLoader.SetObject(characterLoader);
            await UniTask.Yield();
        }
    }
}
