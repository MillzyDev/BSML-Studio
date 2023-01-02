namespace BSMLStudio.Commands
{
    public class CopyCommand : ICommand
    {
        public string Name { get; set; } = "copy";
        public string Description { get; set; } = "Copies a file to the environment.";
        public string Usage { get; set; } = "<filepath>";
        public uint RequiredArgsCount { get; set; } = 1;

        public bool Execute(string[] args)
        {
            Environment.Instance.CopyToEnvironment(args[0]);
            Console.WriteLine("Successfully copied file to the environment!");
            return true;
        }
    }
}
