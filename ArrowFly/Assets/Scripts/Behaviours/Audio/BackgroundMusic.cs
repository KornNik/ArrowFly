using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class BackgroundMusic
    {
        private AudioSource _audioSource;

        public BackgroundMusic()
        {
            Initialize();
            Configure();
        }
        public BackgroundMusic(AudioSource audioSource)
        {
            _audioSource = audioSource;
            Configure();
        }

        public void StartPlayingMusic(AudioClip audioClip)
        {
            if (_audioSource.isPlaying)
            {
                StopPlayingMusic();
            }
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
        public void StopPlayingMusic()
        {
            _audioSource.Stop();
            _audioSource.clip = null;
        }

        private void Initialize()
        {
            var audioSourcePrefab = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetAudioPrefab
                (AudioTypes.BackgroundSourcePrefab).GetComponent<AudioSource>();
            _audioSource = GameObject.Instantiate(audioSourcePrefab, Vector3.zero, Quaternion.identity);
        }
        private void Configure()
        {
            _audioSource.loop = true;
        }
    }
}
