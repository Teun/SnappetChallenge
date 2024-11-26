using SnappetChallenge.Classroom.Domain.Errors;

namespace SnappetChallenge.Classroom.Api.Extensions;

public static class ResultExtensions
{
    public static IResult ToProblemDetails(this Error result)
    {
        return Results.Problem(
            statusCode: StatusCodes.Status400BadRequest,
            title: "Bad Request",
            type: "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/400",
            extensions: new Dictionary<string, object?>
            {
                {"errors", new [] { result.Description } }
            });
    }
}
