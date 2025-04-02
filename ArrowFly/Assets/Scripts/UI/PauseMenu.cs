using UnityEngine;
using UnityEngine.UI;
using Controllers;

namespace UI
{
    class PauseMenu : BaseUI
    {
        [SerializeField] Button _resumeButton;
        [SerializeField] Button _quitButton;
        [SerializeField] private LayoutGroup _buttonsGroup;


        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(OnResumeButtonDown);
            _quitButton.onClick.AddListener(OnQuitButtonDown);
        }
        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(OnResumeButtonDown);
            _quitButton.onClick.RemoveListener(OnQuitButtonDown);

        }

        private void OnResumeButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.GameMenu);
        }

        private void OnQuitButtonDown()
        {
            Application.Quit();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();

        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }
    }
}
