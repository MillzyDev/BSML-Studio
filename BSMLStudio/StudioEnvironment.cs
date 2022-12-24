namespace BSMLStudio
{
    internal class StudioEnvironment
    {
        public static string Environment { get => Directory.GetCurrentDirectory(); }
        public static string Logs { get => Path.Combine(Environment, "Logs"); }
    }
}
