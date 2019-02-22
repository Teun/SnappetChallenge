using StudentsAPI.WebApi.Definitions;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsAPI.WebApi.DTOs
{
    public class GetProgressDTO
    {
        public Domain? Domain { get; set; }

        [Required]
        public int? Month { get; set; }

        [Required]
        public int? Year { get; set; }
    }
}
