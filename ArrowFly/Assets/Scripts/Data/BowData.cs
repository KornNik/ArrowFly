using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "BowData", menuName = "Data/BowData")]
    sealed class BowData : ScriptableObject
    {
        [SerializeField] private float _launchForce = 0.2f;
        [SerializeField] private AudioClip _startDrawAudioClip;
        [SerializeField] private AudioClip _releaseDrawAudioClip;

        public float LaunchForce => _launchForce;
        public AudioClip StartDrawAudioClip => _startDrawAudioClip;
        public AudioClip ReleaseDrawAudioClip => _releaseDrawAudioClip;
    }
}
