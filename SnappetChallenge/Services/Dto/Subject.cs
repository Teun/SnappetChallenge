using System.Collections.Generic;

namespace Services.Dto
{
    public class Subject
    {
        public string Name { get; set; }
        public int AverageProgress { get; set; }
        public IReadOnlyCollection<string> Domains { get; set; }
    }
}