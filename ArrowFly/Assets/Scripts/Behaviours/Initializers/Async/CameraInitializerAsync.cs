using Cysharp.Threading.Tasks;
using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class CameraInitializerAsync : IInitializationAsync
    {
        private CamerasInitilaizationData _camerasData;

        public async UniTask InitializationAsync()
        {
            CamerasDataInitialization();
            MainCameraInitialization();

            await UniTask.Yield();
        }

        private void CamerasDataInitialization()
        {
            var dataResources = Services.Instance.DatasBundle.ServicesObject.GetData<CamerasInitilaizationData>();
            _camerasData = dataResources;
        }
        private void MainCameraInitialization()
        {
            var mainCameraResource = Services.Instance.DatasBundle.ServicesObject.GetData<DataResourcePrefabs>().GetCamerPrefab();
            var mainCameraObject = GameObject.Instantiate(mainCameraResource, _camerasData.GetMainCameraPosition(), Quaternion.identity).GetComponent<Camera>();

            Services.Instance.CameraService.SetObject(mainCameraObject);
        }
    }
}
