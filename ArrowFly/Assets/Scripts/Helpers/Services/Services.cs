using System;
using UnityEngine;
using Behaviours;
using Data;
using Helpers.Extensions;
using Controllers;

namespace Helpers
{
    sealed class Services
    {
        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        public static Services Instance => _instance.Value;
        public Service<InputActions> Inputs { get; private set; }
        public Service<Camera> CameraService { get; private set; }
        public Service<DatasBundle> DatasBundle { get; private set; }
        public Service<ILevelLoader> LevelLoader { get; private set; }
        public Service<IAudioPlayer> AudioPlayer { get; private set; }
        public Service<ITimeController> TimeController { get; private set; }
        public Service<GameStateBehaviour> GameStateBehavior { get; private set; }
        public Service<ISettingsController> SettingsController { get; private set; }
        public Service<DataResourcePrefabs> DataResourcePrefabs { get; private set; }

        public Services()
        {
            Initialize();
        }

        private void Initialize()
        {
            Inputs = new Service<InputActions>();
            CameraService = new Service<Camera>();
            DatasBundle = new Service<DatasBundle>();
            AudioPlayer = new Service<IAudioPlayer>();
            LevelLoader = new Service<ILevelLoader>();
            TimeController = new Service<ITimeController>();
            GameStateBehavior = new Service<GameStateBehaviour>();
            SettingsController = new Service<ISettingsController>();
            DataResourcePrefabs = new Service<DataResourcePrefabs>();
        }

    }
}
