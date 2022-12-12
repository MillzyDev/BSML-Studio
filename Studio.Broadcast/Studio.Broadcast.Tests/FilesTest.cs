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

        [Fact]
        public void LinkTest()
        {
            var instance = Files.Instance;
            instance.LinkFile(ExamplePath);

            Directory.Delete(ExamplePath, true);
        }

        [Fact]
        public void AddTest()
        {
            var instance = Files.Instance;
            instance.AddFile(ExamplePath);

            Directory.Delete(ExamplePath, true);
        }
    }
}