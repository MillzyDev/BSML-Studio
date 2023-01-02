using BSMLStudio.Managers;
using ModestTree;
using Zenject;

namespace BSMLStudio.Commands
{
    public class HelpCommand : ICommand
    {
        [Inject]
        private CommandManager _commandManager;

        public string Name { get; set; } = "help";
        public string Description { get; set; } = "Provides a list of available commands.";
        public string Usage { get; set; } = "";
        public uint RequiredArgsCount { get; set; } = 0;

        public bool Execute(string[] args)
        {
            ICommand[] commands = _commandManager.Commands.Values.ToArray();

            List<string> commandList = new();
            Array.ForEach(commands, command => commandList.Add($"{command.Name} - {command.Description}"));
            string commandListString = commandList.Join("\n");

            Console.WriteLine($"Found {commandList.Count} commands:\n{commandListString}\n\nUse \"<command> help\" for more specific information.");
            return true;
        }
    }
}
