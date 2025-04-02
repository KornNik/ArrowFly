using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CamerasInitilaizationData", menuName = "Data/Camera/CamerasInitilaizationData")]
    class CamerasInitilaizationData : ScriptableObject
    {
        [SerializeField] private Vector3 _mainCameraPosition;

        public Vector3 GetMainCameraPosition()
        {
            return _mainCameraPosition;
        }
    }
}
