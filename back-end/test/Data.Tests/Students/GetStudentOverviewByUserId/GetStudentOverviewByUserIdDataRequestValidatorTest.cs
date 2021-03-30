using Data.Students.GetStudentOverviewByUserId;
using FluentValidation.TestHelper;
using Xunit;

namespace Data.Tests.Students.GetStudentOverviewByUserId
{
    public class GetStudentOverviewByUserIdDataRequestValidatorTest
    {
        private readonly GetStudentOverviewByUserIdDataRequestValidator _validator;

        public GetStudentOverviewByUserIdDataRequestValidatorTest()
        {
            _validator = new GetStudentOverviewByUserIdDataRequestValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ValidateUserId_Invalid_ThrowsException(int userId)
        {
            // Arrange            
            var request = new GetStudentOverviewByUserIdDataRequest
            {
                UserId = userId
            };

            // Assert
            _validator.ShouldHaveValidationErrorFor(r => r.UserId, request);
        }
    }
}
