using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorBoard.Dal.Data;
using TutorBoard.Dal.Dtos;
using TutorBoard.Dal.Repositories;
using Xunit;

namespace TutorBoard.Dal.Tests.Repositories
{
    public class SubjectRepositoryTests
    {
        private IEnumerable<WorkDto> _testData;

        public SubjectRepositoryTests()
        {
            _testData = new List<WorkDto>
            {
                new WorkDto {Subject = "Subject 1"},
                new WorkDto {Subject = "Subject 1"},
                new WorkDto {Subject = "Subject 2"},
                new WorkDto {Subject = "Subject 3"},
                new WorkDto {Subject = "Subject 2"},
                new WorkDto {Subject = "Subject 1"},
            };
        }

        [Fact]
        public async Task TestGetAsync()
        {
            var contextMock = new Mock<IDataContext>();

            // Setup
            contextMock.Setup(c => c.GetWorkData()).Returns(_testData);

            var repository = new SubjectRepository(contextMock.Object);

            // Act
            var result = await repository.GetAsync();

            // Verify
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }
    }
}
