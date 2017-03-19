using System.IO;
using System.Reflection;

namespace Snappet.TestData.Helpers
{
    public class ResourceDataLoader
    {
        public string LoadResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}