using Dapper;
using Data.Utils;
using MediatR;
using Sdk.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Students.GetStudentsOverview
{
    public class GetStudentsOverviewDataRequestHandler : IRequestHandler<GetStudentsOverviewDataRequest, GetStudentsOverviewDataResponse>
    {
        private readonly IStudentDbConnection _studentDbConnection;

        public GetStudentsOverviewDataRequestHandler(IStudentDbConnection studentDbConnection)
        {
            _studentDbConnection = studentDbConnection;
        }

        public async Task<GetStudentsOverviewDataResponse> Handle(GetStudentsOverviewDataRequest request, CancellationToken cancellationToken)
        {
            const string sql = @"
                                SELECT
	                                UserId                   AS UserId,
                                    Subject                  AS Subject,
                                    COUNT(SubmittedAnswerId) AS AnswerCount,     
                                    MIN(Progress)            AS Min,
                                    AVG(Progress)            AS Mean,
                                    MAX(Progress)            AS High
                                FROM answers
                                GROUP BY 
	                                UserId, Subject 
                                ORDER BY 
	                                UserId,
                                    MAX(Progress);";

            using var connection = _studentDbConnection.GetConnection();
            connection.Open();

            var items = await connection.QueryAsync<StudentOverviewEntity>(sql);

            return new GetStudentsOverviewDataResponse
            {
                Items = items.ToList()
            };
        }
    }
}
