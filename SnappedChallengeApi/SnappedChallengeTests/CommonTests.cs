using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnappedChallengeTests.Constants;
using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi.Models.Commons;
using SnappedChallengeApi.RestClients;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SnappedChallengeTests
{
    /// <summary>
    /// Common APIs Unit Tests
    /// </summary>
    [TestClass]
    public class CommonTests
    {
        /// <summary>
        /// TestInitialize method
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            ServiceSettings.ServiceAddress = TestConstants.HostUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public async Task CommonScenario()
        {
           
            //There is only true result expected so lets check it
            var result = await CommonRestClient.Instance().GetPingResult();
            Assert.IsTrue(result);

        }

    }
}
