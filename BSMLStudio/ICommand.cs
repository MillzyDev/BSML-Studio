namespace BSMLStudio
{
    public interface ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Usage { get; set; }
        public uint RequiredArgsCount { get; set; }

        public bool Execute(string[] args);
    }
}
