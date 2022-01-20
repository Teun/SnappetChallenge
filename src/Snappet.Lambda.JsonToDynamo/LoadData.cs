using System.IO;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using System.Text;
using Newtonsoft.Json;
using Snappet.Lambda.JsonToDynamo.Model;
using System.Collections.Generic;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Snappet.Lambda.JsonToDynamo
{
    public class LoadData
    {
        AwsConfig _config;
        public LoadData()
        {
            _config = new AwsConfig()
            {
                AccessKeyId = "",
                SecretAccessKey = ""
            };
        }
        public async Task LoadDataHandler(string input, ILambdaContext context)
        {
            await GetS3DataFileAsync();
        }
        private async Task GetS3DataFileAsync()
        {
            var s3Client = new AmazonS3Client(_config.AccessKeyId, _config.SecretAccessKey);
            var buckets = await s3Client.ListBucketsAsync();
            if (buckets == null) return;
            foreach (var bucket in buckets.Buckets)
            {
                var currentBucket = await s3Client.ListObjectsAsync(bucket.BucketName);
                if (currentBucket == null) return;
                if (bucket.BucketName == "snappet-bucket")
                {
                    foreach (var contentItem in currentBucket.S3Objects)
                    {
                        if (contentItem == null)
                        {

                            return;
                        }
                        else if (contentItem.Key == "work.json")
                        {
                            var response = await s3Client.GetObjectAsync(new GetObjectRequest
                            {
                                BucketName = bucket.BucketName,
                                Key = contentItem.Key,
                            });

                            var data = DeserializeData(response.ResponseStream);
                            await LoadJsonToDynamo(data);
                        }
                    }
                }
            }
        }

        private async Task LoadJsonToDynamo(List<SubmittedAnswers> data)
        {
            DynamoDBClient dynamoClient = new DynamoDBClient(_config);
            await dynamoClient.SaveAnswersAsync(data);
        }

        private List<SubmittedAnswers>  DeserializeData(Stream stream)
        {
            using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                string content = streamReader.ReadToEnd();
                var submittedAnswers = JsonConvert.DeserializeObject<List<SubmittedAnswers>>(content);
                return submittedAnswers;
            }
            
        }

    }
}