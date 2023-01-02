using BSMLStudio.Installers;
using Serilog;
using Serilog.Core;
using Zenject;

namespace BSMLStudio
{
    public class BSMLStudio : IDisposable
    {
        private readonly DiContainer _container;
        private DisposableManager? _disposableManager;

        private readonly Logger _logger;

        protected internal BSMLStudio()
        {
            _container = new DiContainer();

            string logFile = Path.Combine(StudioDirectories.Logs, $"{DateTime.Now:yyyy.MM.dd.HH.mm.ss}.log");

            _logger = new LoggerConfiguration()
                .WriteTo.File(logFile)
                .CreateLogger();

            _logger.Information($"Created new log at {logFile}");
            _logger.Information("BSMLStudio instance initialised successfully!");
        }

        public DiContainer Container => _container;

        protected internal void Run()
        {
            try
            {
                _logger.Information("Binding primary dependencies to container...");
                InstallBindings();

                _logger.Information("Resolving initial dependencies...");
                ResolveDependencies();
            }
            catch (Exception e)
            {
                _logger.Fatal(e, "Uncaught Exception!");
            }
        }

        private void InstallBindings()
        {
            _logger.Information($"Binding {nameof(InitializableManager)}...");
            _container.Bind<InitializableManager>().AsSingle();

            _logger.Information($"Binding {nameof(DisposableManager)}...");
            _container.Bind<DisposableManager>().AsSingle();

            _logger.Information($"Binding {nameof(Logger)} instance...");
            _container.Bind<Logger>().FromInstance(_logger).AsSingle();

            _logger.Information($"Installing {nameof(CommandInstaller)}...");
            _container.Install<CommandInstaller>();

            _logger.Information($"Installing {nameof(AppInstaller)}...");
            _container.Install<AppInstaller>();

            _logger.Information($"Installing {nameof(MainSequenceInstaller)}...");
            _container.Install<MainSequenceInstaller>();
        }

        private void ResolveDependencies()
        {
            _disposableManager = _container.Resolve<DisposableManager>();
            _container.Resolve<InitializableManager>().Initialize();

            _logger.Information("Resolved dependencies!");
        }

        public void Dispose()
        {
            _disposableManager?.Dispose();
            GC.SuppressFinalize(this);
            _logger.Information("Exiting...");
        }
    }
}