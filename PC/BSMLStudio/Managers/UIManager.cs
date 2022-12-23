using BeatSaberMarkupLanguage.MenuButtons;
using BSMLStudio.UI.FlowCoordinators;
using System;
using Zenject;

namespace BSMLStudio.Managers
{
    class UIManager : IInitializable, IDisposable
    {
        [Inject]
        private StudioFlowCoordinator studioFlowCoordinator;

        private MenuButton menuButton;

        public void Initialize()
        {
            menuButton = new MenuButton("BSML Studio", OnMenuButtonClick);
            MenuButtons.instance.RegisterButton(menuButton);
        }

        private void OnMenuButtonClick()
        {
            studioFlowCoordinator.Show();
        }

        public void Dispose()
        {
            MenuButtons.instance.UnregisterButton(menuButton);
        }
    }
}
