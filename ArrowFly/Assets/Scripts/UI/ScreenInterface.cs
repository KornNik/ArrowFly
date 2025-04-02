using System;
using Helpers;

namespace UI
{
    sealed class ScreenInterface : IDisposable
    {
        private BaseUI _currentWindow;
        private readonly ScreenFactory _screenFactory;
        private static ScreenInterface _instance;

        private ScreenInterface()
        {
            _screenFactory = new ScreenFactory();
        }

        public BaseUI CurrentWindow => _currentWindow;

        public static ScreenInterface GetInstance()
        {
            return _instance ?? (_instance = new ScreenInterface());
        }

        public void Execute(ScreenTypes screenType)
        {
            if (CurrentWindow != null)
            {
                CurrentWindow.Hide();
            }

            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _currentWindow = _screenFactory.GetGameMenu();
                    break;
                case ScreenTypes.MainMenu:
                    _currentWindow = _screenFactory.GetMainMenu();
                    break;
                case ScreenTypes.PauseMenu:
                    _currentWindow = _screenFactory.GetPauseMenu();
                    break;
                default:
                    break;
            }

            CurrentWindow.Show();
        }

        public void AddObserver(ScreenTypes screenType, IListenerScreen listenerScreen)
        {
            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _screenFactory.GetGameMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetGameMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetGameMenu().Hide();
                    break;
                case ScreenTypes.MainMenu:
                    _screenFactory.GetMainMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetMainMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetMainMenu().Hide();
                    break;
                case ScreenTypes.PauseMenu:
                    _screenFactory.GetPauseMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetPauseMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetPauseMenu().Hide();
                    break;
                default:
                    break;
            }
        }

        public void RemoveObserver(ScreenTypes screenType, IListenerScreen listenerScreen)
        {
            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _screenFactory.GetGameMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetGameMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetGameMenu().Hide();
                    break;
                case ScreenTypes.MainMenu:
                    _screenFactory.GetMainMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetMainMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetMainMenu().Hide();
                    break;
                case ScreenTypes.PauseMenu:
                    _screenFactory.GetPauseMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetPauseMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetPauseMenu().Hide();
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _instance = null;
        }
    }
}
