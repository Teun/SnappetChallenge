using System;

namespace StudentsAPI.WebApi.DTOs
{
    public class GetWorkItemsDTO
    {
        public int? UserId { get; set; }
        public string Domain { get; set; }
        public DateTime? SubmitDateTime { get; set; }
        public int PageNumber { get; set; }
    }
}
