using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.S3Events;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Newtonsoft.Json;
using Snappet.TeachersPortal.DataAccess;
using Snappet.TeachersPortal.Model;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Snappet.TeachersPortal.DataImporter
{
    public class Function
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IWorkItemRepository _workItemRepository;

        
        public Function()
        {
            _s3Client = new AmazonS3Client();
            _workItemRepository = new WorkItemRepository();
        }

        public Function(IAmazonS3 s3Client, IWorkItemRepository workItemRepository)
        {
            _s3Client = s3Client;
            _workItemRepository = workItemRepository;

        }
        

        public async Task FunctionHandler(S3Event evnt)
        {
            var s3Event = evnt.Records?[0].S3;

            try
            {
                GetObjectResponse response = await _s3Client.GetObjectAsync(s3Event.Bucket.Name, s3Event.Object.Key);

                using (var reader = new StreamReader(response.ResponseStream))
                {
                    var data = await reader.ReadToEndAsync();

                    var workItems = JsonConvert.DeserializeObject<IEnumerable<WorkItem>>(data);

                    await _workItemRepository.PersistWorkItemsAsync(workItems);
                    await _workItemRepository.PersistWorkSummaryAsync(workItems);
                }


            }
            catch(Exception e)
            {

                Console.Write(e.ToString());
                throw;
            }
        }
    }
}
