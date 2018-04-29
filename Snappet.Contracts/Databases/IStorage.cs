using Snappet.Contracts.Assesments.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.Databases
{
    public interface IStorage
    {
        TotalResult GetWorksResult();
    }
}
