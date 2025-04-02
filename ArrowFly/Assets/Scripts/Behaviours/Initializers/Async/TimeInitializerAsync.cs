using Helpers;
using Controllers;
using Cysharp.Threading.Tasks;

namespace Behaviours
{
    sealed class TimeInitializerAsync : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var timeController = new TimeController();
            Services.Instance.TimeController.SetObject(timeController);

            await UniTask.Yield();
        }
    }
}
