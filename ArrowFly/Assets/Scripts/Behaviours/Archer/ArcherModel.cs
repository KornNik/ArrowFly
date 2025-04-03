using UnityEngine;

namespace Behaviours
{
    sealed class ArcherModel : MonoBehaviour
    {
        [SerializeField] Launcher _bow;
        [SerializeField] ArcherAnimation _animation;

        private IKTransforms _ikTargets;

        public IBow Bow  => _bow; 
        public ArcherAnimation Animation  => _animation;
        public IKTransforms IkTargets => _ikTargets;

        private void Awake()
        {
            _ikTargets = _bow.IkTargets;
        }
    }

}
