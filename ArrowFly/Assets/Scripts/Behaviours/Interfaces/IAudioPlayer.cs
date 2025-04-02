using UnityEngine;

namespace Behaviours
{
    interface IAudioPlayer
    {
        void PlaySound(SoundEventInfo soudnInfo);
        void SwitchMutedState();
        void SetSoundStatus(bool status);
        bool IsSoundMuted();
        void PlayBackgroundMusic(AudioClip backgroundMusic);
    }
}
