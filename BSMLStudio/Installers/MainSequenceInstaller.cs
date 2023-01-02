using BSMLStudio.Managers;
using Serilog.Core;
using Zenject;

namespace BSMLStudio.Installers
{
    internal class MainSequenceInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainSequenceManager>().AsSingle();
        }
    }
}
