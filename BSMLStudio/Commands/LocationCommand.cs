using System.Diagnostics;

namespace BSMLStudio.Commands
{
    public class LocationCommand : ICommand
    {
        public string Name { get; set; } = "location";
        public string Description { get; set; } = "Prints the environment path to the console or opens the environment folder.";
        public string Usage { get; set; } = "[open]";
        public uint RequiredArgsCount { get; set; } = 0;

        public bool Execute(string[] args)
        {
            if (args.Length > RequiredArgsCount && args[0].ToLower() == "open")
            {
                Process.Start("explorer.exe", Environment.Instance.EnvironmentPath);
                return true;
            }
            else
            {
                Console.WriteLine(Environment.Instance.EnvironmentPath);
                return true;
            }
        }
    }
}
