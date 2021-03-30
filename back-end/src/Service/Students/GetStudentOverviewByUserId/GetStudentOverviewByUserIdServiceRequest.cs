using MediatR;

namespace Service.Students.GetStudentOverviewByUserId
{
    public class GetStudentOverviewByUserIdServiceRequest : IRequest<GetStudentOverviewByUserIdServiceResponse>
    {
        public int UserId { get; set; }
    }
}
