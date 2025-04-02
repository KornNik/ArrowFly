using Helpers;

namespace Behaviours
{
    struct MutedInfo
    {
        public bool IsMuted;
    }
    struct MuteSoundEvent
    {
        private static MuteSoundEvent _muteSoundEvent;

        private MutedInfo _mutedInfo;
        internal MutedInfo MutedInfo => _mutedInfo;

        public static void Trigger(MutedInfo mutedInfo)
        {
            _muteSoundEvent._mutedInfo = mutedInfo;
            EventManager.TriggerEvent(_muteSoundEvent);
        }
    }
}
