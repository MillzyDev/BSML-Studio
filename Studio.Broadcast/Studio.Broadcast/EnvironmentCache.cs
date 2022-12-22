namespace Studio.Broadcast
{
    /// <summary>
    /// Runs when the <see cref="EnvironmentCache"/> begins to check files for edits.
    /// </summary>
    /// <param name="files">Array of file paths that are checked.</param>
    public delegate void OnRefresh(string[] files);

    public class EnvironmentCache : IDisposable
    {
        private static readonly Lazy<EnvironmentCache> _lazy = new(() => new EnvironmentCache());

        public event OnRefresh? OnRefresh;

        private readonly Dictionary<string, string> cacheData = new();

        private Environment environment;

        private EnvironmentCache()
        {
            environment = Environment.Instance;

            using var watcher = new FileSystemWatcher(environment.EnvironmentPath);
            watcher.NotifyFilter = // main things we want to trigger the cache to update.
                NotifyFilters.FileName
                | NotifyFilters.Size
                | NotifyFilters.LastWrite
                | NotifyFilters.Attributes;

            watcher.Changed += OnChange;

            watcher.Filter = "*.bsml"; // only bsml files
            watcher.IncludeSubdirectories = false;
            watcher.EnableRaisingEvents = true; // enable our OnChange event to be invoked.

            Refresh();
        }

        /// <summary>
        /// NOTE: This will only update files already registered within the cache.
        /// New files can be registered in <see cref="Refresh"/>
        /// </summary>
        private void OnChange(object sender, FileSystemEventArgs e)
        {
            
        }

        /// <summary>
        /// Reloads all files in the cache
        /// </summary>
        public void Refresh()
        {
            string[] files = Environment.Instance.GetFiles();

            foreach (var file in files)
            {
                cacheData[file] = File.ReadAllText(file);
            }

            OnRefresh?.Invoke(files);
        }

        public static EnvironmentCache Instance => _lazy.Value;

        public void Dispose()
        {
            //Cease();
        }
    }
}
