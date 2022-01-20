using HotChocolate;
using HotChocolate.Types;
using Snappet.GraphQL.API.DbContext;
using Snappet.GraphQL.API.Model;
using Snappet.GraphQL.API.Service;

namespace Snappet.GraphQL.API.Schemma
{
    [GraphQLDescription("Queries available")]
    public class Query
    {

        [UseDbContext(typeof(DynamoDbContext<SubmittedAnswers>))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Queryable submitted answers")]
        public IQueryable<SubmittedAnswers> GetSubmittedAnswers([ScopedService] DynamoDbContext<SubmittedAnswers> context)
        {
            return context.SubmittedAnswers;
        }

        [UseDbContext(typeof(DynamoDbContext<SubmittedAnswers>))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable command")]
        public IQueryable<Command> GetCommand([ScopedService] DynamoDbContext<SubmittedAnswers> context)
        {
            return context.Command;
        }
    }

}
