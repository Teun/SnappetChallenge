using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;

namespace Snappet.TeachersPortal.DataAccess.DataEntities
{
    [DynamoDBTable("-work-summary")]
    class WorkSummaryEntity
    {
        [DynamoDBHashKey]
        public string SummaryDate { get; set; }

        [DynamoDBProperty]
        public List<WorkSummaryDomainEntity> Domains { get; set; }

        [DynamoDBProperty]
        public int StudentsNumber { get; set; }

        [DynamoDBProperty]
        public double AverageDifficulty { get; set; }

        [DynamoDBProperty]
        public double AverageCorrectness { get; set; }

    }

    class WorkSummaryDomainEntity
    {
        [DynamoDBProperty]
        public string Domain { get; set; }
        
        [DynamoDBProperty]
        public int StudentsNumber { get; set; }

        [DynamoDBProperty]
        public double AverageDifficulty { get; set; }

        [DynamoDBProperty]
        public double AverageCorrectness { get; set; }

    }



}
