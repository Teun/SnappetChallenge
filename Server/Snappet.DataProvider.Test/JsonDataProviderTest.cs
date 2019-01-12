using NUnit.Framework;
using Snappet.DataProvider.DataProvider;
using System;
using System.Configuration;
using System.IO;

namespace Snappet.DataProvider.Test
{
    [TestFixture]
    public class JsonDataProviderTest
    {
        JsonDataProvider jsonDataprovide;
        public JsonDataProviderTest()
        {
            jsonDataprovide = new JsonDataProvider();
        }

        public void setupMock(bool isValid)
        {
            jsonDataprovide.FilePath = isValid ? ".\\Snappet.WebAPI\\App_data\\work.json" : "";
        }
        [Test]
        public void GetWorkDetails_WithvalidInput_ReturnValidData()
        {
            setupMock(true);
            var result = jsonDataprovide.GetWorkDetails();
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetWorkDetails_WithvalidInput_ReturnNull()
        {
            setupMock(false);
            var result = jsonDataprovide.GetWorkDetails();
            Assert.IsNull(result);
        }
    }
}
