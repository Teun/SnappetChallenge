using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Snappet.Entity;

namespace Snappet.Model
{
    public class AutoCompleteResponse
    {
        public AutoCompleteItem[] Items { get; set; }
    }
}