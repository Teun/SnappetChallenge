using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snappet.Models.Database.StoredProcedures.Rep
{
    /// <summary>
    /// Get careless students during a range of date
    /// Who is careless? If could solve hard questions but failed on easy questions.
    /// </summary>
    public class SP_SubmittedAnswers_CarelessStudents
    {
        public class Inputs : IValidatableObject
        {
            /// <summary>
            /// The report start date-time point. It could be null. 
            /// If pass null, means don't set any limitation for the start point.
            /// </summary>
            public DateTime? FromDate { get; set; }

            /// <summary>
            /// The report end-date point. It could be null.
            /// If pass null, means don't set any limmitation for the end point.
            /// </summary>
            public DateTime? ToDate { get; set; }

            /// <summary>
            /// Validate date range
            /// </summary>
            /// <param name="validationContext"></param>
            /// <returns></returns>
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (FromDate.HasValue && ToDate.HasValue && ToDate < FromDate)
                {
                    yield return new ValidationResult(
                        errorMessage: "ToDate must be greater than FromDate",
                        memberNames: new[] { "ToDate" }
                   );
                }
            }
        }

        public class Outputs
        {
            /// <summary>
            /// Number of students were careless during the datetime range limitation
            /// </summary>
            public int StudentNumber { get; set; }
            
            /// <summary>
            /// The DomainId that students were careless at
            /// </summary>
            public int DomainId { get; set; }

            /// <summary>
            /// The Domain title that students were careless at
            /// </summary>
            public string Domain { get; set; }
        }
    }
}
