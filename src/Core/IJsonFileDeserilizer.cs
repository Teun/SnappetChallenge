using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Core
{
    public interface IJsonFileDeserilizer
    {
        Task<T> Deserilize<T>(string filePath);
    }
}
