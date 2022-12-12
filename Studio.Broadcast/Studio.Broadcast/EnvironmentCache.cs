namespace Studio.Broadcast
{
    public delegate void OnRefresh();
    public delegate void OnReload();

    public class EnvironmentCache : IDisposable
    {
        private static readonly Lazy<EnvironmentCache> _lazy = new(() => new EnvironmentCache());

        public event OnRefresh? OnRefresh;
        public event OnReload? OnReload;

        private readonly Dictionary<string, string> cacheData = new();
        private readonly Task refreshRoutine;
        private bool refresh;

        private Environment environment;

        private EnvironmentCache()
        {
            environment = Environment.Instance;

            Refresh();

            refresh = true;
            refreshRoutine = Task.Run(AutoRefreshRoutine);
        }

        public static EnvironmentCache Instance => _lazy.Value;

        public void Refresh()
        {
            OnRefresh?.Invoke();

            string[] files = environment.GetFiles();

            bool mismatch = false;
            foreach (string file in files)
            {
                try
                {
                    string content = File.ReadAllText(file);
                    mismatch = cacheData[file] != content;
                }
                catch
                {
                    mismatch = true;
                }
            }

            if (files.Length != cacheData.Count || mismatch)
            {
                // Reload
                foreach (string file in files)
                {
                    cacheData[file] = File.ReadAllText(file);
                }

                OnReload?.Invoke();
            }
        }

        public void Cease()
        {
            refresh = false;
        }

        private void AutoRefreshRoutine()
        {
            while (refresh)
            {

            }
        }

        public void Dispose()
        {
            Cease();
        }
    }
}
