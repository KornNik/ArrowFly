using Helpers;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Behaviours
{
    sealed class LoadLevelState : BaseState
    {
        private ILevelLoader _levelLoader;
        private Launcher _launcher;
        private ArrowTorque _arrowTorque;

        public LoadLevelState(GameStateController stateController) : base(stateController)
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }

        public override void EnterState()
        {
            base.EnterState();
            LoadAll().Forget();
        }
        private async UniTaskVoid LoadAll()
        {
            await LoadTask(LoadLevelBehaviours);
            await LoadTask(LoadBowAndArrow);
            await LoadTask(StartGameState);
        }

        private async UniTask LoadTask(Action loadingAction)
        {
            loadingAction?.Invoke();
            await UniTask.Yield();
        }
        private void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelByIndex(0);
        }
        private void LoadBowAndArrow()
        {
            _arrowTorque =  GameObject.Instantiate(Services.Instance.DataResourcePrefabs.ServicesObject.GetArrow());
            _launcher = GameObject.Instantiate(Services.Instance.DataResourcePrefabs.ServicesObject.GetLauncher());
        }
        private void StartGameState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
    }
}
