using Zenject;

namespace BSMLStudio.Managers
{
    internal class CommandManager
    {
        private Dictionary<string, ICommand> commands = new();

        CommandManager(DiContainer container)
        {
            container.ResolveAll<ICommand>().ForEach(x => commands[x.Name] = x);
        }

        public Dictionary<string, ICommand> Commands => commands;
    }
}
