namespace BSMLStudio.Commands
{
    public class RemoveCommand : ICommand
    {
        public string Name { get; set; } = "remove";
        public string Description { get; set; } = "Removes a file from the environment.";
        public string Usage { get; set; } = "<filepath>";
        public uint RequiredArgsCount { get; set; } = 1;

        public bool Execute(string[] args)
        {
            Environment.Instance.RemoveFromEnvironment(args[0]);
            Console.WriteLine("Successfully removed file from the environment!");
            return true;
        }
    }
}
