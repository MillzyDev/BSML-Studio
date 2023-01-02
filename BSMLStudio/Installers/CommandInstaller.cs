using BSMLStudio.Commands;
using Zenject;

namespace BSMLStudio.Installers
{
    internal class CommandInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HelpCommand>().AsSingle();
            Container.BindInterfacesAndSelfTo<HelpCommand>().AsSingle();
            Container.BindInterfacesAndSelfTo<LinkCommand>().AsSingle();
            Container.BindInterfacesAndSelfTo<ListCommand>().AsSingle();
            Container.BindInterfacesAndSelfTo<LocationCommand>().AsSingle();
            Container.BindInterfacesAndSelfTo<RemoveCommand>().AsSingle();
        }
    }
}
