using System;
using System.IO;
using Xunit;

namespace Studio.Broadcast.Tests
{
    public class EnvironmentTests : IDisposable
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

            Assert.True(
                Array.Exists(
                    Directory.GetFiles(instance.EnvironmentPath),
                    x => Path.GetFileName(ExamplePath) == Path.GetFileName(x)
                    )
                );
        }

        [Fact]
        public void AddTest()
        {
            var instance = Environment.Instance;
            instance.AddFile(Example2Path);

            Assert.True(
                Array.Exists(
                    Directory.GetFiles(instance.EnvironmentPath),
                    x => Path.GetFileName(Example2Path) == Path.GetFileName(x)
                    )
                );
        }

        public void Dispose()
        {
            var files = Directory.EnumerateFiles(Environment.Instance.EnvironmentPath);
            foreach (var file in files)
            {
                File.Delete(file);
            }
        }
    }
}