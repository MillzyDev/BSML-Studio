using BeatSaberMarkupLanguage;
using BSMLStudio.UI.ViewControllers;
using HMUI;
using Zenject;

namespace BSMLStudio.UI.FlowCoordinators
{
    class StudioFlowCoordinator : FlowCoordinator
    {
        [Inject]
        private DisplayViewController displayViewController;

        [Inject]
        private StudioViewController studioViewController;

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("BSML Studio");
                showBackButton = true;

                ProvideInitialViewControllers(displayViewController, studioViewController);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
            => BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this);

        public void Show()
        {
            FlowCoordinator parent = BeatSaberUI.MainFlowCoordinator.YoungestChildFlowCoordinatorOrSelf();

            Plugin.Log.Info((parent == null).ToString());

            BeatSaberUI.PresentFlowCoordinator(parent, this);
        }
    }
}
