using ModestTree;
using Serilog.Core;
using System.Reflection;
using Zenject;

namespace BSMLStudio.Managers
{
    public class MainSequenceManager : IInitializable
    {
        private readonly string startupMessage = "######   #####  #     # #           #####                               \r\n#     # #     # ##   ## #          #     # ##### #    # #####  #  ####  \r\n#     # #       # # # # #          #         #   #    # #    # # #    # \r\n######   #####  #  #  # #           #####    #   #    # #    # # #    # \r\n#     #       # #     # #                #   #   #    # #    # # #    # \r\n#     # #     # #     # #          #     #   #   #    # #    # # #    # \r\n######   #####  #     # #######     #####    #    ####  #####  #  ####  \r\n                                                                        \r\n";
        private readonly Logger _logger;

        private readonly Dictionary<string, ICommand> commands;

        MainSequenceManager(Logger logger, CommandManager commandManager)
        {
            _logger = logger;

            commands = commandManager.Commands;
        }

        public void Initialize()
        {
            ConsoleRoutine();
        }

        public void ConsoleRoutine()
        {
            Console.WriteLine(startupMessage);

            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.Title = string.Format("{0} v{1}\n", assembly.GetName().Name, assembly.GetName().Version);
            Console.WriteLine("{0} v{1}\n", assembly.GetName().Name, assembly.GetName().Version);

            string? currentCommand = string.Empty;

            do
            {
                Console.Write("> ");
                string? input = Console.ReadLine();
               
                string[]? args = input?.Split(" ", StringSplitOptions.TrimEntries);

                if (args.IsEmpty() || args == null)
                {
                    continue;
                }

                currentCommand = args[0].ToLower();

                _logger.Information($"Attempting to execute {currentCommand}...");

                // bullshit to remove the command
                List<string> temp = new(args);
                temp.RemoveAt(0);
                args = temp.ToArray();

                bool found = commands.TryGetValue(currentCommand, out ICommand? command);
                if (!found || command == null)
                {
                    _logger.Information($"Unable to find command for \"{currentCommand}\"");
                    Console.WriteLine($"Unable to find command for \"{currentCommand}\"");
                    continue;
                }

                if (args.Length < 0 && args[0].ToLower() == "help") 
                {
                    Console.WriteLine($"{currentCommand} - {command.Description}\n      {command.Usage}");
                    _logger.Information($"Displaying help for {currentCommand}");
                    continue;
                }

                if (args.Length < command.RequiredArgsCount)
                {
                    Console.WriteLine($"Unable to execute {currentCommand} command; not enough arguments were provided");
                    Console.WriteLine($"{currentCommand} requires at least {command.RequiredArgsCount} arguments.");
                    Console.WriteLine();
                    Console.WriteLine($"{currentCommand} - {command.Description}\n      {command.Usage}");
                }

                bool success = command.Execute(args);

                if (!success)
                {
                    Console.WriteLine($"Something went wrong when executing {currentCommand}. :/");
                }
            } 
            while (currentCommand.ToLower() != "quit");
        }

        public void RegisterCommand(ICommand command)
        {
            commands[command.Name] = command;
        }

        public void UnregisterCommand(ICommand command)
        {
            commands.Remove(command.Name);
        }
    }
}
