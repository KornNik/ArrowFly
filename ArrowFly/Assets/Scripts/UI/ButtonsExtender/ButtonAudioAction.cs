using Behaviours;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "ButtonAudioAction", menuName = "Data/Buttons/ButtonAudioAction")]
    class ButtonAudioAction: ButtonExtenderAction, IBtnExtenderAction
    {
        [SerializeField] private AudioClip _clickClip;

        public override void PerformAction()
        {
            MakeSoundEvent.Trigger(new SoundEventInfo(_clickClip, Vector3.zero));
        }
    }
}
