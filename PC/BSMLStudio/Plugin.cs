using BSMLStudio.Installers;
using IPA;
using IPA.Config;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace BSMLStudio
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        public void Init(Zenjector zenjector, Config config,IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("BSMLStudio initialized.");

            Log.Info("Configuring Zenjector...");
            zenjector.UseLogger(logger);
            zenjector.UseMetadataBinder<Plugin>();

            zenjector.Install<MenuInstaller>(Location.Menu);
        }
    }
}
