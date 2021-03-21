using System.ComponentModel.DataAnnotations;

namespace Snappet.Models.Database.StoredProcedures.dbo
{
    /// <summary>
    /// Authenticate teachers
    /// </summary>
    public class SP_Teacher_Login
    {
        /// <summary>
        /// Input data for calling SP
        /// </summary>
        public class Inputs
        {
            /// <summary>
            /// Teacher username that may not be an email address. It could be a simple username like 'admin'.
            /// </summary>
            [Required]
            [MaxLength(200)]
            [MinLength(3)]
            public string Email { get; set; }

            /// <summary>
            /// Teacher password
            /// </summary>
            [Required]
            [MaxLength(50)]
            public string Password { get; set; }
        }

        /// <summary>
        /// Stored-Procedure result
        /// </summary>
        public class Outputs
        {
            public int TeacherId { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}