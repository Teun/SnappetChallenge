using Dapper;
using Data.Utils;
using MediatR;
using Sdk.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Teachers.GetTeacherDashboard
{
    public class GetTeacherDashboardDataRequestHandler : IRequestHandler<GetTeacherDashboardDataRequest, GetTeacherDashboardDataResponse>
    {
        private readonly IStudentDbConnection _studentDbConnection;

        public GetTeacherDashboardDataRequestHandler(IStudentDbConnection studentDbConnection)
        {
            _studentDbConnection = studentDbConnection;
        }

        public async Task<GetTeacherDashboardDataResponse> Handle(GetTeacherDashboardDataRequest request, CancellationToken cancellationToken)
        {
            const string sql = @"
                                SELECT 
	                                Subject                  AS Subject,
                                    Domain                   AS Domain,     
                                    LearningObjective        AS LearningObjective,
                                    Count(SubmittedAnswerId) AS AnswerCount,
                                    DATE(SubmitDateTime)     AS SubmitDateTime
                                FROM answers 
                                WHERE 
	                                Domain <> '-' 
                                GROUP BY 
	                                Subject,
                                    Domain,
                                    LearningObjective,
                                    DATE(SubmitDateTime) 
                                ORDER BY 
	                                COUNT(UserId) DESC;";

            using var connection = _studentDbConnection.GetConnection();
            connection.Open();

            var items = await connection.QueryAsync<DashboardEntity>(sql);

            return new GetTeacherDashboardDataResponse
            {
                Items = items.ToList()
            };
        }
    }
}
