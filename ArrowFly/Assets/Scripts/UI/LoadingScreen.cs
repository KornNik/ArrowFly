using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    class LoadingScreen : BaseUI
    {
        [SerializeField] private Image _loadingBar;
        [SerializeField] private TextMeshProUGUI _loadingText;

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

        public void ShowProgress(float asyncProgress)
        {
            var progreessPercent = asyncProgress * 100;
            ShowLoadingText(progreessPercent);
            ShowLoadingBar(asyncProgress);
        }
        private void ShowLoadingBar(float asyncProgress)
        {
            _loadingBar.fillAmount = asyncProgress;
        }
        private void ShowLoadingText(float asyncProgressPercent)
        {
            _loadingText.text = asyncProgressPercent.ToString();
        }
    }
}
