using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    sealed class ButtonExtender : MonoBehaviour
    {
        [SerializeField] private Button _extendedButton;
        [SerializeField] private ButtonExtenderAction[] _actions;

        private void OnEnable()
        {
            _extendedButton.onClick.AddListener(CustomButtonClick);
        }
        private void OnDisable()
        {
            _extendedButton.onClick.RemoveListener(CustomButtonClick);
        }

        private void CustomButtonClick()
        {
            for (int i = 0; i < _actions.Length; i++)
            {
                _actions[i].PerformAction();
            }
        }
    }
}
