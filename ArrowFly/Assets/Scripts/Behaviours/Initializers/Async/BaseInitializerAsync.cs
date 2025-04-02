using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace Behaviours
{
    abstract class BaseInitializerAsync : IInitializationAsync
    {
        private List<IInitializationAsync> _initializers = new List<IInitializationAsync>();

        public List<IInitializationAsync> Initializers => _initializers;

        public async UniTask InitializationAsync()
        {
            FillInitializers();
            await InitializeAsync();
        }
        public async UniTask InitializeAsync()
        {
            foreach (var initializer in _initializers)
            {
                await initializer.InitializationAsync();
            }
        }
        protected abstract void FillInitializers();
    }
}
