using BSMLStudio.Managers;
using Zenject;

namespace BSMLStudio.Installers
{
    class AppInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CommandManager>().AsSingle();
        }
    }
}
