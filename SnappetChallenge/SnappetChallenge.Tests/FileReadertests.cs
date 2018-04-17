namespace SnappetChallenge.Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EFGetStarted.AspNetCore.NewDb.Models;
    using Moq;
    using SnappetChallenge.Core;
    using Xunit;

    public class FileReaderTests
    {
        IReportDatabaseLayer MoqRepo;
        public FileReaderTests()
        {
            var moqRepo = new Mock<IReportDatabaseLayer>();
            moqRepo.Setup(x => x.AddClassReportItem(It.IsAny<List<ReportItem>>())).Returns(Task.FromResult<object>(null));
            MoqRepo = moqRepo.Object;
        }

        [Fact]
        public async Task TestReadBigJson()
        {
            var fileReader = new ReportFileReader(MoqRepo);
            await fileReader.ReadBigJson<ReportItem>("./jsons/ReportInput.json");
        }
    }
}
