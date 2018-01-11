using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Mvc.Models
{
    public class WorkItemsMetadata
    {
        public int TotalCount;
        public int[] AllUserIds;
        public string[] AllDomains;
        public string[] AllLearningObjectives;
        public int[] AllCorrects;
        public int[] AllProgresses;
        public int[] AllExerciseIds;
        public string[] AllDifficulties;
    }
}
