namespace BSMLStudio
{
    public class Program
    {
        private static BSMLStudio? bsmlStudio;

        public static void Main()
        {
            bsmlStudio = new BSMLStudio();
            bsmlStudio.Run();
        }
    }
}