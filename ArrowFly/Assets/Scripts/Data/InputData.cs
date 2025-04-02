using UnityEngine;
using UnityEngine.InputSystem;

namespace Data
{
    [CreateAssetMenu(fileName ="InputData",menuName ="Data/InputData")]
    sealed class InputData : ScriptableObject
    {
        [SerializeField] private InputActionAsset _inputActionAsset;

        public InputActionAsset InputActionAsset => _inputActionAsset;
    }
}
