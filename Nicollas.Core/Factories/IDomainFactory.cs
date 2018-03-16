using Nicollas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nicollas.Core.Factories
{
    public interface IDomainFactory : IFactory<Domain, int>
    {
        Task<int> GetDomainId(Domain domain);
    }
}
