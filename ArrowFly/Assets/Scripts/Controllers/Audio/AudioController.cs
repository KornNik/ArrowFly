using UnityEngine;
using Behaviours;
using Helpers;
using Data;

namespace Controllers
{
    sealed class AudioController : MonoBehaviour, IAudioPlayer
    {
        private AudioMixerVolumeMuter _audioMixerMuter;

        private AudioSourcePool _audioSourcePool;
        private AudioEventsHandler _audioEventsHandler;
        private BackgroundMusic _backgroundMusic;

        private EventSubscriptionWraper _eventSubscriptionWrapper;

        public void Awake()
        {
            Initialize();
            FillSubscriptions();
        }
        private void OnEnable()
        {
            _eventSubscriptionWrapper.Subscribe();
        }
        private void OnDisable()
        {
            _eventSubscriptionWrapper.Unsubscribe();
        }

        private void Initialize()
        {
            _audioMixerMuter = Services.Instance.DatasBundle.ServicesObject.
                GetData<AudioMixerVolumeMuter>();

            _audioSourcePool = new AudioSourcePool();
            _backgroundMusic = new BackgroundMusic();
            _audioEventsHandler = new AudioEventsHandler(this);
            _eventSubscriptionWrapper = new EventSubscriptionWraper();
        }
        private void FillSubscriptions()
        {
            _eventSubscriptionWrapper.AddEvent(_audioEventsHandler);
        }

        public void PlaySound(SoundEventInfo soudnInfo)
        {
            if (soudnInfo.IsOneShot)
            {
                _audioSourcePool.PlayAtPointOneShot(soudnInfo.AudioClip, soudnInfo.PlayPosition, soudnInfo.SoundVolume);
            }
            else
            {
                _audioSourcePool.PlayAtPoint(soudnInfo.AudioClip, soudnInfo.PlayPosition, soudnInfo.SoundVolume);
            }
        }
        public void PlayBackgroundMusic(AudioClip backgroundMusic)
        {
            _backgroundMusic.StartPlayingMusic(backgroundMusic);
        }

        public void SwitchMutedState()
        {
            _audioMixerMuter.Muted = !_audioMixerMuter.Muted;
        }
        public void SetSoundStatus(bool status)
        {
            _audioMixerMuter.Muted = status;
        }
        public bool IsSoundMuted()
        {
            return _audioMixerMuter.Muted;
        }
    }
}