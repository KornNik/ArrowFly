using UnityEngine;
using Data;
using Helpers;

namespace CameraScripts
{
    internal class CameraModel
    {
        private Camera _camera;
        private CameraData _cameraData;

        public CameraModel()
        {
            _camera = Camera.main;
            _cameraData = Services.Instance.DatasBundle.ServicesObject.GetData<CameraData>();
        }
    }
}