using Snappet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Domain.Interface.Service
{
    public interface IProgressCalculatorService
    {
        int CalculateProgress(int userId, DateOnly date);
    }
}
