using System.Collections.Generic;

namespace Snappet.Model
{
    public class SubjectDto
    {
        public string Subject { get; set; }

        public IEnumerable<AppraisalDto> Appraisal { get; set; }
    }
}
