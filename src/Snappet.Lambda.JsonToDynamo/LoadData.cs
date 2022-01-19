using System.IO;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;
using Snappet.Lambda.JsonToDynamo.Model;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Snappet.Lambda.JsonToDynamo
{
    public class LoadData
    {
        public async Task LoadDataHandler(string input, ILambdaContext context)
        {
            await GetS3DataFileAsync("kYsusPwEKmCY+G4IYyAkeQymQHCjHTTD5gLGbltC", "AKIA2FJCLRSUYZRSIRF3");
        }
        private async Task GetS3DataFileAsync(string secretAccessKey, string accessKeyId)
        {
            var s3Client = new AmazonS3Client(accessKeyId, secretAccessKey);
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
                            LoadJsonToDynamo(secretAccessKey, accessKeyId, data);
                        }
                    }
                }
            }
        }

        private void LoadJsonToDynamo(string secretAccessKey, string accessKeyId, List<SubmittedAnswers> data)
        {
            throw new NotImplementedException();
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

        public record Casing(string Lower, string Upper);
    }
}