namespace BSMLStudio.Commands
{
    public class ListCommand : ICommand
    {
        public string Name { get; set; } = "list";
        public string Description { get; set; } = "Lists all files currently in the BSMLStudio Environment.";
        public string Usage { get; set; } = "";
        public uint RequiredArgsCount { get; set; } = 0;

        public bool Execute(string[] args)
        {
            string[] files = Environment.Instance.GetFiles();
            string list = string.Join(",\n ", files);

            Console.WriteLine($"Files in the environment:\n {list}");
            return true;
        }
    }
}
