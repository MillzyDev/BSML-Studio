namespace Studio.Broadcast
{
    public class Environment
    {
        private static readonly Lazy<Environment> _lazy = new(() => new Environment());

        private readonly string environmentPath;

        private Environment()
        {
            string appdata = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            environmentPath = Path.Combine(appdata, "BSMLStudio", "Environment");

            Directory.CreateDirectory(environmentPath);
        }

        public static Environment Instance => _lazy.Value;

        /// <summary>
        /// Full path of the BSMLStudio Environment directory.
        /// </summary>
        public string EnvironmentPath
        {
            get => environmentPath;
        }

        /// <summary>
        /// Creates a symbolic link of a file in the BSMLStudio environment. (REQUIRES ADMIN PERMS)
        /// </summary>
        /// <param name="file">Full path of the file to link to the environment.</param>
        /// <returns>FileSystemInfo of the symbolic link created.</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public FileSystemInfo LinkFile(string file)
        {
            if (!File.Exists(file)) throw new FileNotFoundException($"The file \"{file}\" could not be found. ");

            string name = Path.GetFileName(file);
            string linkPath = Path.Combine(environmentPath, name);

            var info = File.CreateSymbolicLink(linkPath, file);

            return info;
        }

        /// <summary>
        /// Copies a file to the BSMLStudio environment.
        /// </summary>
        /// <param name="file">Full path of the file to add to the environment.</param>
        /// <exception cref="FileNotFoundException"></exception>
        public void AddFile(string file)
        {
            if (!File.Exists(file)) throw new FileNotFoundException($"The file \"{file}\" could not be found. ");

            string name = Path.GetFileName(file);
            string copyPath = Path.Combine(environmentPath, name);

            File.Copy(file, copyPath);
        }

        /// <summary>
        /// Removes a file from the BSMLStudio environment.
        /// </summary>
        /// <param name="name">The name of the file (including any extensions) excluding the full path.</param>
        public void RemoveFile(string name)
        {
            string path = Path.Combine(environmentPath, name);
            File.Delete(path);
        }

        /// <summary>
        /// Gets a list of file paths of all the top directory files in the Environment directory.
        /// </summary>
        /// <returns></returns>
        public string[] GetFiles() => Directory.GetFiles(environmentPath, "*", SearchOption.TopDirectoryOnly);
    }
}