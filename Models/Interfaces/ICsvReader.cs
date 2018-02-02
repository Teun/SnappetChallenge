using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Models.Interfaces
{
    public interface ICsvReader
    {
        List<ClassAssignment> ReadFile(string s);
    }
}
