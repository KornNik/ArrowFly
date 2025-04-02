using CameraScripts;
using UnityEngine;

namespace Controllers
{
    internal class CameraController : MonoBehaviour
    {
        private CameraModel _cameraModel;
        private CameraMovement _cameraMovement;

        public void Awake()
        {
            _cameraModel = new CameraModel();
            _cameraMovement = new CameraMovement();
        }

        public void LateUpdate()
        {

        }
    }
}
