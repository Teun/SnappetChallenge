
using Amazon;
using Amazon.Lambda.Core;
using Amazon.S3;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Snappet.Challenge.DataFileToDynamoDB
{
    public class LoadData
    {

        public string LoadDataHandler(ILambdaContext context)
        {
            //await UploadDataFileAsync();
            context.Logger.Log("My debug log!");
            return "My debug log!";
        }

        private async Task UploadDataFileAsync()
        {
            string bucketName = "snappet-bucket";
            string bucketKey = "work.json";

            using (var client = new AmazonS3Client(RegionEndpoint.EUWest2))
            {
                var response = await client.GetObjectAsync(bucketName, bucketKey);
                using (var reader = new StreamReader(response.ResponseStream))
                {
                    
                    Debug.WriteLine(await reader.ReadToEndAsync());
                }
            }
        }
    }

    public record Casing(string Lower, string Upper);
}
