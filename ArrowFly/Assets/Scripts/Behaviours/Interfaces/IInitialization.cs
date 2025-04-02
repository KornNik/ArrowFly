using Cysharp.Threading.Tasks;

namespace Behaviours
{
    interface IInitialization
    {
        void Initialization();
    }
    interface IInitializationAsync
    {
        UniTask InitializationAsync();
    }
}
