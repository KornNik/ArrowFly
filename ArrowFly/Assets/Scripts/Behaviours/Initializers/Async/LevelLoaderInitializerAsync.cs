using Cysharp.Threading.Tasks;
using Helpers;

namespace Behaviours
{
    sealed class LevelLoaderInitializerAsync : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var lelveLoader = new LevelLoader();
            Services.Instance.LevelLoader.SetObject(lelveLoader);
            await UniTask.Yield();
        }
    }
}
