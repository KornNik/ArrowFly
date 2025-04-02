using UnityEngine;
using Data;
using Helpers;

namespace Behaviours
{
    class GameStateControllerInitializer : IInitialization
    {
        public void Initialization()
        {
            var gameStatePrefab = Services.Instance.DatasBundle.ServicesObject.GetData<DataResourcePrefabs>().GetGameStatePrefab();
            var gameState = GameObject.Instantiate(gameStatePrefab).GetComponent<GameStateBehaviour>();
            Services.Instance.GameStateBehavior.SetObject(gameState);
        }
    }
}