using Serilog.Core;
using Zenject;

namespace BSMLStudio.Commands
{
    public class LinkCommand : ICommand
    {
        [Inject]
        private Logger _logger;

        public string Name { get; set; } = "link";
        public string Description { get; set; } = "Symbolically links a file to the environment.";
        public string Usage { get; set; } = "<filepath>";
        public uint RequiredArgsCount { get; set; } = 1;

        public bool Execute(string[] args)
        {
            Environment.Instance.LinkToEnvironment(args[0]);
            Console.WriteLine("Successfully linked file to the environment!");
            return true;
        }
    }
}
