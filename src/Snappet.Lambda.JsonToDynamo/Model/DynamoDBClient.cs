using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snappet.Lambda.JsonToDynamo.Model
{

    public class DynamoDBClient : IDynamoDBClient
    {
        private readonly AmazonDynamoDBClient _amazonDynamoDBClient;
        private readonly DynamoDBContext _context;

        public DynamoDBClient(AwsConfig config)
        {

            _amazonDynamoDBClient = new AmazonDynamoDBClient(config.AccessKeyId, config.SecretAccessKey, RegionEndpoint.EUWest2);
            _context = new DynamoDBContext(_amazonDynamoDBClient);
        }

        public async Task SaveAnswersAsync(List<SubmittedAnswers> submittedAnswers)
        {
            //This takes too lon
            foreach (var item in submittedAnswers)          
            {
                await _context.SaveAsync(item);
            }
        }
    }
} 