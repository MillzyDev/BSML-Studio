using BeatSaberMarkupLanguage;
using BSMLStudio.Managers;
using BSMLStudio.UI.FlowCoordinators;
using BSMLStudio.UI.ViewControllers;
using Zenject;

namespace BSMLStudio.Installers
{
    class MenuInstaller : Installer
    {
        private DisplayViewController defaultViewController;
        private StudioViewController studioViewController;

        private StudioFlowCoordinator studioFlowCoordinator;

        public override void InstallBindings()
        {
            Container.Bind<DisplayViewController>().FromNewComponentAsViewController().AsSingle();
            Container.Bind<StudioViewController>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesAndSelfTo<StudioFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
            Container.BindInterfacesAndSelfTo<UIManager>().AsSingle();
        }
    }
}
