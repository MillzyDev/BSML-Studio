using SysEnvironment = System.Environment;

namespace BSMLStudio.Environment
{
    public class Environment
    {
        private static readonly Lazy<Environment> _environment = new(() => new Environment());

        private readonly string envPath = Path.Combine(SysEnvironment.GetFolderPath(SysEnvironment.SpecialFolder.ApplicationData), "BSMLStudio", "Environment");

        private Environment()
        {
            if (!Directory.Exists(envPath))
                Directory.CreateDirectory(envPath);
        }

        public static Environment Instance => _environment.Value;

        public string EnvironmentPath => envPath;

        /// <summary>
        /// Gets the names and extensions of all files in the Environment.
        /// </summary>
        /// <returns>An array of file names.</returns>
        public string[] GetFiles()
        {
            string[] fullFiles = Directory.GetFiles(envPath, "*.bsml", SearchOption.TopDirectoryOnly);
            List<string> files = new();
            Array.ForEach(fullFiles, x => files.Add(Path.GetFileName(x)));
            return files.ToArray();
        }

        /// <summary>
        /// Reads the content of a file in the environment
        /// </summary>
        /// <param name="name">The file name and extension (no path)</param>
        /// <returns></returns>
        public string ReadFile(string name)
        {
            return File.ReadAllText(Path.Combine(envPath, name));
        }

        /// <summary>
        /// Copies a file to the environment
        /// </summary>
        /// <param name="path">The full path of the file to copy.</param>
        /// <exception cref="ArgumentException">Thrown if the file is not a .bsml file.</exception>
        public void CopyToEnvironment(string path)
        {
            if (!path.EndsWith(".bsml"))
                throw new ArgumentException("File must be a .bsml file.");

            File.Copy(path, Path.Combine(envPath, Path.GetFileName(path)));
        }

        /// <summary>
        /// Creates a symbolic link of a specified file in the environment.
        /// </summary>
        /// <param name="path">Path of the file to link.</param>
        /// <exception cref="ArgumentException">Thrown if the file is not a .bsml file.</exception>
        public void LinkToEnvironment(string path)
        {
            if (!path.EndsWith(".bsml"))
                throw new ArgumentException("File must be a .bsml file.");

            string name = Path.GetFileName(path);
            File.CreateSymbolicLink(path, Path.Combine(envPath, name));
        }
    }
}