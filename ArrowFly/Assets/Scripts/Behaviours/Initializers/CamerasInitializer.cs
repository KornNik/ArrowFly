using UnityEngine;
using Data;
using Helpers;

namespace Behaviours
{
   sealed class CamerasInitializer : IInitialization
    {
        private CamerasInitilaizationData _camerasData;
        public void Initialization()
        {
            CamerasDataInitialization();
            MainCameraInitialization();
        }

        private void CamerasDataInitialization()
        {
            var dataResources = Services.Instance.DatasBundle.ServicesObject.GetData<CamerasInitilaizationData>();
            _camerasData = dataResources;
        }
        private void MainCameraInitialization()
        {
            var mainCameraResource = Services.Instance.DatasBundle.ServicesObject.GetData<DataResourcePrefabs>().GetCamerPrefab();
            var mainCameraObject = Object.Instantiate(mainCameraResource, _camerasData.GetMainCameraPosition(), Quaternion.identity).GetComponent<Camera>();

            Services.Instance.CameraService.SetObject(mainCameraObject);
        }
    }
}
