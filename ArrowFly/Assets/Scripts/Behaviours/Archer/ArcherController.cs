using UnityEngine;

namespace Behaviours
{
    sealed class ArcherController : MonoBehaviour 
    {
        [SerializeField] private ArcherModel _model;

        public ArcherModel Model => _model;
    }

}
