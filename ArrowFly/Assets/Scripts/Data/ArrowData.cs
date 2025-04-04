using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ArrowData", menuName = "Data/ArrowData")]
    sealed class ArrowData : ScriptableObject
    {
        [SerializeField] private AudioClip _hitClip;

        public AudioClip HitClip => _hitClip; 
    }
}
