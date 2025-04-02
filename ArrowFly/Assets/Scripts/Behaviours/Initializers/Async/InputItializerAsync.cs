using Controllers;
using Cysharp.Threading.Tasks;

namespace Behaviours
{
    sealed class InputItializerAsync : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var inputController = new InputLoader();

            await UniTask.Yield();
        }
    }
}
