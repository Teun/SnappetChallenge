using StudentsAPI.WebApi.Definitions;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsAPI.WebApi.DTOs
{
    public class GetWorkItemsDTO
    {
        public int? UserId { get; set; }
        public Domain? Domain { get; set; }
        public DateTime? SubmitDateTime { get; set; }
        public int PageNumber { get; set; } = 0;
    }
}
