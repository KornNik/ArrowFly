using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName ="BowData",menuName ="Data/BowData")]
    sealed class BowData : ScriptableObject
    {
        [SerializeField] private float _launchForce = 0.2f;

        public float LaunchForce => _launchForce;
    }
}
