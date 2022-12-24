using BSMLStudio.Commands;
using Zenject;

namespace BSMLStudio.Installers
{
    internal class CommandInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ListCommand>().AsSingle();
        }
    }
}
