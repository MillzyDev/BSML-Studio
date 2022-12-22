namespace Studio.Broadcast
{
    /// <summary>
    /// This is used to communicate between BSML Studio and Quest devices.
    /// </summary>
    public class Broadcaster
    {
        private static readonly Lazy<Broadcaster> _lazy = new(() => new Broadcaster());

        private Broadcaster()
        {
            //TODO: A lot.
        }

        public static Broadcaster Instance => _lazy.Value;

        public ushort Port { get; } = 62098;
    }
}
