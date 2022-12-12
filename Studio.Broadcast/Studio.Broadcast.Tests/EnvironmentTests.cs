using System.IO;
using Xunit;

namespace Studio.Broadcast.Tests
{
    public class EnvironmentTests
    {
        public static string ExamplePath
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "Examples", "Test.bsml");
            }
        }

        public static string Example2Path
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "Examples","Test2.bsml");
            }
        }

        [Fact]
        public void LinkTest()
        {
            var instance = Environment.Instance;
            instance.LinkFile(ExamplePath);
        }

        [Fact]
        public void AddTest()
        {
            var instance = Environment.Instance;
            instance.AddFile(Example2Path);
        }
    }
}