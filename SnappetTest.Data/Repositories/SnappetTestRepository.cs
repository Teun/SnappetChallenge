using SnappetTest.Data.Abstract;
using SnappetTest.Model.Entities;
using Microsoft.Extensions.Options;
using SnappetTest.Data.Attributes;
namespace SnappetTest.Data.Repositories

{
  public class SnappetTestRepository : EntityBaseRepository<ReceivedAnswers>, ISnappetTestRepository
    {
        public SnappetTestRepository(ISnappetFactory snappetDatabase, IOptions<MongoAttributes> attributeMongo ) 
            : base(snappetDatabase, attributeMongo.Value.SubmittedAnswersCollection)
        {

        }
    }
}
