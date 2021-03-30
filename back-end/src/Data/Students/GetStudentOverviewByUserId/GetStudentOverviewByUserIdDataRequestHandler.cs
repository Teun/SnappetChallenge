using Dapper;
using Data.Utils;
using MediatR;
using Sdk.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Students.GetStudentOverviewByUserId
{
    public class GetStudentOverviewByUserIdDataRequestHandler : IRequestHandler<GetStudentOverviewByUserIdDataRequest, GetStudentOverviewByUserIdDataResponse>
    {
        private readonly IStudentDbConnection _studentDbConnection;

        public GetStudentOverviewByUserIdDataRequestHandler(IStudentDbConnection studentDbConnection)
        {
            _studentDbConnection = studentDbConnection;
        }

        public async Task<GetStudentOverviewByUserIdDataResponse> Handle(GetStudentOverviewByUserIdDataRequest request, CancellationToken cancellationToken)
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
                                WHERE 
                                    UserId = @UserId
                                GROUP BY 
	                                UserId, Subject 
                                ORDER BY 
	                                UserId,
                                    MAX(Progress);";

            using var connection = _studentDbConnection.GetConnection();
            connection.Open();

            var items = await connection.QueryAsync<StudentOverviewEntity>(sql, request);

            return new GetStudentOverviewByUserIdDataResponse
            {
                Items = items.ToList()
            };
        }
    }
}
