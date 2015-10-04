using System.Collections.Generic;
using Snappet.Domain.Contracts;

namespace Snappet.Models
{
    public class DashboardViewModel
    {
        public List<Domain.Contracts.Domain> Domains { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}