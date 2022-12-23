using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BSMLStudio
{
    public static class ResourceUtils
    {
        public static string GetResourceContent(string name)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(name))
            {
                StreamReader streamReader = new StreamReader(stream);
                string content = streamReader.ReadToEnd();
                return content;
            }
        }
    }
}
