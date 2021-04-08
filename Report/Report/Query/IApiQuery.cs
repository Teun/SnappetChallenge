using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.Query
{
    public class ApiQueryResult<T>
    {
        public ApiQueryResult(T t)
        {
            Value = t;
        }

        public T Value { get; }
    }

    public interface IApiQuery<T>
    { 
        Task<ApiQueryResult<T>> Execute();
    }
}
