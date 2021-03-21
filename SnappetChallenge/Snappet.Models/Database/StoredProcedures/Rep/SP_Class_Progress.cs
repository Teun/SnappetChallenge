using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snappet.Models.Database.StoredProcedures.Rep
{
    /// <summary>
    /// What has my class been working on today?
    /// </summary>
    public class SP_Class_Progress
    {
        /// <summary>
        /// Report input params
        /// </summary>
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
            public string Domain { get; set; }
            public string Subject { get; set; }
            public string LearningObjective { get; set; }

            /// <summary>
            /// Total time all students spend (seconds)
            /// </summary>
            public int TotalTime { get; set; }
        }
    }
}
