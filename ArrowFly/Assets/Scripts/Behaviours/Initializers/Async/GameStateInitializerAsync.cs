using Cysharp.Threading.Tasks;
using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class GameStateInitializerAsync : IInitializationAsync
    {

        public async UniTask InitializationAsync()
        {
            var gameStatePrefab = Services.Instance.DatasBundle.ServicesObject.GetData<DataResourcePrefabs>().GetGameStatePrefab();
            var gameState = GameObject.Instantiate(gameStatePrefab).GetComponent<GameStateBehaviour>();
            Services.Instance.GameStateBehavior.SetObject(gameState);

            await UniTask.Yield();
        }
    }
}
