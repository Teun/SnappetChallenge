using MediatR;

namespace Data.Students.GetStudentOverviewByUserId
{
    public class GetStudentOverviewByUserIdDataRequest : IRequest<GetStudentOverviewByUserIdDataResponse>
    {
        public int UserId { get; set; }
    }
}
