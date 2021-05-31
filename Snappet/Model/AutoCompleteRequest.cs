using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Snappet.Entity;

namespace Snappet.Model
{
    public class AutoCompleteRequest
    {
        [DefaultValue(5)]
        [Range(0, 10)]
        public int Count { get; set; } = 5;
        
        [Required]
        public string Keyword { get; set; } 
        
        [Required]
        public AutoCompleteType Type { get; set; }
    }
}