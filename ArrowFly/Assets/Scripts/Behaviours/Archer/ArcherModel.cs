using UnityEngine;

namespace Behaviours
{
    sealed class ArcherModel : MonoBehaviour
    {
        [SerializeField] Launcher _bow;
        [SerializeField] ArcherAnimation _animation;

        private IKTransforms _ikTargets;
        private ArcherCombat _combat;

        public ArcherAnimation Animation  => _animation;
        public IKTransforms IkTargets => _ikTargets;
        public ArcherCombat Combat => _combat;

        private void Awake()
        {
            _ikTargets = _bow.IkTargets;
            _combat = new ArcherCombat(_bow);
        }
    }

}
