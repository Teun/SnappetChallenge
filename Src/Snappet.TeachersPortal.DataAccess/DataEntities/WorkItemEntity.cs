using Amazon.DynamoDBv2.DataModel;
using System;

namespace Snappet.TeachersPortal.DataAccess.DataEntities
{
    [DynamoDBTable("-work-item")]
    class WorkItemEntity
    {
        [DynamoDBHashKey]
        public string AnswerId { get; set; }

        [DynamoDBRangeKey("ItemDate")]
        public string ItemDate { get; set; }

        [DynamoDBProperty]
        public bool Correct { get; set; }

        [DynamoDBProperty]
        public int UserId { get; set; }

        [DynamoDBProperty]
        public int ExerciseId { get; set; }

        [DynamoDBProperty]
        public double Difficulty { get; set; }

        [DynamoDBProperty]
        public string Subject { get; set; }

        [DynamoDBProperty]
        public string Domain { get; set; }

        [DynamoDBProperty]
        public string LearningObjective { get; set; }
                
    }
}
