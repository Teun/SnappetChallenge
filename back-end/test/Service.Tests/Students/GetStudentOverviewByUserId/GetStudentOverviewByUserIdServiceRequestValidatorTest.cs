using FluentValidation.TestHelper;
using Service.Students.GetStudentOverviewByUserId;
using Xunit;

namespace Service.Tests.Students.GetStudentOverviewByUserId
{
    public class GetStudentOverviewByUserIdServiceRequestValidatorTest
    {
        private readonly GetStudentOverviewByUserIdServiceRequestValidator _validator;

        public GetStudentOverviewByUserIdServiceRequestValidatorTest()
        {
            _validator = new GetStudentOverviewByUserIdServiceRequestValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ValidateUserId_Invalid_ThrowsException(int userId)
        {
            // Arrange            
            var request = new GetStudentOverviewByUserIdServiceRequest
            {
                UserId = userId
            };

            // Assert
            _validator.ShouldHaveValidationErrorFor(r => r.UserId, request);
        }
    }
}
