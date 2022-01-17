using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Snappet.Lambda.JsonToDynamo
{
    public class LoadData
    {
        public async Task LoadDataHandler(string input, ILambdaContext context)
        {
            await GetDataFileAsync("kYsusPwEKmCY+G4IYyAkeQymQHCjHTTD5gLGbltC", "AKIA2FJCLRSUYZRSIRF3");
        }
        private async Task GetDataFileAsync(string secretAccessKey, string accessKeyId)
        {
            var s3Client = new AmazonS3Client(accessKeyId, secretAccessKey);
            var buckets  = await s3Client.ListBucketsAsync();
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

                            var buffer = new byte[response.ResponseStream.Length];
                            response.ResponseStream.Read(buffer, 0, buffer.Length);
                            await LoadJsonToDynamo(Encoding.UTF8.GetString(buffer));

                        }
                    }
                    
                }
            }
        
        }
        
        private async Task LoadJsonToDynamo(string jsonText)
        {

        }
    }

    public record Casing(string Lower, string Upper);
}
