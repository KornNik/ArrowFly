using Helpers;

namespace Behaviours
{
    class AudioEventsHandler : IEventListener<MakeSoundEvent>, IEventListener<MuteSoundEvent>, IEventListener<BackgroundMusicEvent>,
        IEventSubscription
    {
        private IAudioPlayer _audioPlayer;

        public AudioEventsHandler(IAudioPlayer audioPlayer)
        {
            _audioPlayer = audioPlayer;
        }

        public void OnEventTrigger(MakeSoundEvent eventType)
        {
            _audioPlayer.PlaySound(eventType.SoundData);
        }

        public void OnEventTrigger(MuteSoundEvent eventType)
        {
            _audioPlayer.SetSoundStatus(eventType.MutedInfo.IsMuted);
        }

        public void OnEventTrigger(BackgroundMusicEvent eventType)
        {
            _audioPlayer.PlayBackgroundMusic(eventType.AudioClip);
        }

        public void Subscribe()
        {
            this.EventStartListening<MakeSoundEvent>();
            this.EventStartListening<MuteSoundEvent>();
            this.EventStartListening<BackgroundMusicEvent>();
        }

        public void Unsubscribe()
        {
            this.EventStopListening<MakeSoundEvent>();
            this.EventStopListening<MuteSoundEvent>();
            this.EventStopListening<BackgroundMusicEvent>();
        }
    }
}