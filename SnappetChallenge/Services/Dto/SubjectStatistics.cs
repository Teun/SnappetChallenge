using System.Collections.Generic;

namespace Services.Dto
{
    public class SubjectStatistics
    {
        public string Name { get; set; }

        public IReadOnlyCollection<DomainStatistics> Domains { get; set; }
    }
}
