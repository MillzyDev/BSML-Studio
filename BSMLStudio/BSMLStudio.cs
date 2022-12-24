using Zenject;

namespace BSMLStudio
{
    public class BSMLStudio : IDisposable
    {
        private readonly DiContainer _container;
        private DisposableManager? _disposableManager;

        protected internal BSMLStudio()
        {
            _container = new DiContainer();
        }

        public DiContainer Container => _container;

        protected internal void Run()
        {
            InstallBindings();
            ResolveDependencies();
        }

        private void InstallBindings()
        {
            _container.Bind<InitializableManager>().AsSingle();
            _container.Bind<DisposableManager>().AsSingle();

            // Install Installers
        }

        private void ResolveDependencies()
        {
            _disposableManager = _container.Resolve<DisposableManager>();
            _container.Resolve<InitializableManager>().Initialize();
        }

        public void Dispose()
        {
            _disposableManager?.Dispose();
        }
    }
}