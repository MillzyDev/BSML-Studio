using System.IO;
using Xunit;

namespace Studio.Broadcast.Tests
{
    public class FilesTest
    {
        public static string ExamplePath
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "Test.bsml");
            }
        }

        public static string Example2Path
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "Test2.bsml");
            }
        }

        [Fact]
        public void LinkTest()
        {
            var instance = Files.Instance;
            instance.LinkFile(ExamplePath);
        }

        [Fact]
        public void AddTest()
        {
            var instance = Files.Instance;
            instance.AddFile(Example2Path);
        }
    }
}