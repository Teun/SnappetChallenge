using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Snappet.TeachersPortal.DataAccess.DataEntities;
using Snappet.TeachersPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.TeachersPortal.DataAccess
{
    public interface IWorkItemRepository
    {
        Task PersistWorkItemsAsync(IEnumerable<WorkItem> workItems);

        Task PersistWorkSummaryAsync(IEnumerable<WorkItem> workItems);
    }


    public class WorkItemRepository: IWorkItemRepository
    {
        private IAmazonDynamoDB _dynamoDBClient { get; set; }

        public WorkItemRepository()
        {
            _dynamoDBClient = new AmazonDynamoDBClient();
        }

        public WorkItemRepository(IAmazonDynamoDB dynamoDBClient)
        {
            _dynamoDBClient = dynamoDBClient;
        }

        public async Task PersistWorkItemsAsync(IEnumerable<WorkItem> workItems)
        {
            using (var context = new DynamoDBContext(_dynamoDBClient, new DynamoDBContextConfig { TableNamePrefix = Environment.GetEnvironmentVariable("DbTablePrefix") }))
            {

                var batch = context.CreateBatchWrite<WorkItemEntity>();

                var entities = workItems.Take(1000).Select(w => new WorkItemEntity
                {
                    AnswerId = w.SubmittedAnswerId,
                    Correct = w.Correct,
                    ItemDate = w.SubmitDate.ToString("yyyy-MM-dd"),
                    Difficulty = w.DifficultyDouble,
                    Domain = w.Domain,
                    ExerciseId = w.ExerciseId,
                    LearningObjective = w.LearningObjective,
                    Subject = w.Subject,
                    UserId = w.UserId

                });

                batch.AddPutItems(entities);

                await batch.ExecuteAsync();
                
            }
        }

        public async Task PersistWorkSummaryAsync(IEnumerable<WorkItem> workItems)
        {
           

            using (var context = new DynamoDBContext(_dynamoDBClient, new DynamoDBContextConfig { TableNamePrefix = Environment.GetEnvironmentVariable("DbTablePrefix") }))
            {

                var batch = context.CreateBatchWrite<WorkSummaryEntity>();

                var entities = workItems.GroupBy(item =>item.SubmitDate).Select(g =>
                     new WorkSummaryEntity
                     {
                         SummaryDate = g.Key.ToString("yyyy-MM-dd"),
                         AverageCorrectness = g.Average(a =>a.Correct ? 1 : 0),
                         AverageDifficulty = g.Average(a => a.DifficultyDouble),
                         StudentsNumber = g.GroupBy(a => a.UserId).Count(),

                         Domains = g.GroupBy(w=>w.Domain).Select(d =>
                             new WorkSummaryDomainEntity
                             {
                                 Domain = d.Key,
                                 AverageCorrectness = d.Average(b => b.Correct ? 1 : 0),
                                 AverageDifficulty = d.Average(b => b.DifficultyDouble),
                                 StudentsNumber = d.GroupBy(b => b.UserId).Count()


                             }).ToList()

                     });

                batch.AddPutItems(entities);

                await batch.ExecuteAsync();

            }

        }
    }

}
