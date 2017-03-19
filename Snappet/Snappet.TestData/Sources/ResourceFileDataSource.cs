using Snappet.TestData.Helpers;

namespace Snappet.TestData.Sources
{
    public class ResourceFileDataSource : ITestDataSource
    {
        private readonly ResourceDataLoader _dataLoader;
        private readonly string _resourceName;

        public ResourceFileDataSource(string resourceName)
        {
            _dataLoader = new ResourceDataLoader();
            _resourceName = resourceName;
        }

        public string GetTestData()
        {
            
            return _dataLoader.LoadResource(_resourceName);
        }
    }
}
