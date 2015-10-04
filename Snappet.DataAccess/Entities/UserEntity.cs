using System.Collections.Generic;


namespace Snappet.DataAccess.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }

        public int SubjectId { get; set; }
        public int TotalAnswers { get; set; }
        public int CorrectAnswers { get; set; }
    }

   
}
