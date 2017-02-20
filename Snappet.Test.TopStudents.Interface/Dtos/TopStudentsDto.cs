using System;

namespace Snappet.Test.TopStudents.Interface.Dtos
{
    public class TopStudentsDto
    {
        public bool HasTop1 => Top1StudentId.HasValue;
        public int? Top1StudentId { get; set; }
        public decimal? Top1Difficulty { get; set; }

        public bool HasTop2 => Top1StudentId.HasValue;
        public int? Top2StudentId { get; set; }
        public decimal? Top2Difficulty { get; set; }

        public bool HasTop3 => Top1StudentId.HasValue;
        public int? Top3StudentId { get; set; }
        public decimal? Top3Difficulty { get; set; }

        public DateTime RecordDate { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
    }
}