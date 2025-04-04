using Cysharp.Threading.Tasks;
using Helpers;

namespace Behaviours
{
    sealed class LevelLoaderInitializerAsync : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var levelLoader = new LevelLoader();
            Services.Instance.LevelLoader.SetObject(levelLoader);
            await UniTask.Yield();
        }
    }
}
