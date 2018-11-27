using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnappedChallengeTests.Constants;
using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi.Models.Commons;
using SnappedChallengeApi.Models.Commons.ApiCommons;
using SnappedChallengeApi.RestClients;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SnappedChallengeTests
{
    /// <summary>
    /// Every controller should have a unit test class
    /// </summary>
    [TestClass]
    public class ClassworkTests
    {
        /// <summary>
        /// Classword APIs Unit Tests
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            ServiceSettings.ServiceAddress = TestConstants.HostUrl;
    }

        /// <summary>
        /// Classwork Test Main Scenario Usually i generate a basic main test that combines other sub tests for execution
        /// </summary>
        [TestMethod]
        public async Task ClassWorkTestScenario()
        {
            //basic date interval test
            var recordsToBeExpected = await ClassworkRestClient.Instance().GetClassworkSummary(TestConstants.StartDate, TestConstants.EndDate);
            Assert.IsTrue(recordsToBeExpected.IsNotNullAndEmpty() && recordsToBeExpected.All(f => f.Date >= TestConstants.StartDate && f.Date <= TestConstants.EndDate ));

            //no record test
            var noRecordsExpected = await ClassworkRestClient.Instance().GetClassworkSummary(TestConstants.EndDate, TestConstants.EndDate);
            Assert.IsTrue(!noRecordsExpected.Any() || !recordsToBeExpected.All(f => f.Date >= TestConstants.StartDate && f.Date <= TestConstants.EndDate));
            
            //basic paging check
            QueryParameter qp = new QueryParameter();
            qp.Offset = 0;
            qp.Limit = 10;
            var getFirstTenRecords = await ClassworkRestClient.Instance().GetClassworkSummary(qp);

            Assert.IsTrue(getFirstTenRecords.Any() && getFirstTenRecords.Count == qp.Limit);

            //no record check
            qp = new QueryParameter();
            qp.Offset = 10000000;
            qp.Limit = 10;
            noRecordsExpected = await ClassworkRestClient.Instance().GetClassworkSummary(qp);

            Assert.IsTrue(!noRecordsExpected.Any() || !recordsToBeExpected.All(f => f.Date >= TestConstants.StartDate && f.Date <= TestConstants.EndDate));

        }

    }
}
