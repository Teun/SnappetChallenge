using Nicollas.Core;
using Nicollas.Core.Entities;
using Nicollas.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nicollas.Imp.Factory
{
    public class DomainFactory : Factory<Domain, int>, IDomainFactory
    {
        public DomainFactory(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        public async Task<int> GetDomainId(Domain domain)
        {
            var entity = this.Repository.FindByCriteria(row => row.Description.Equals(domain.Description));
            if (entity == null)
            {
                this.Repository.Add(domain);
                await this.UnitOfWork.CommitAsync();
                return domain.Id;
            }

            return entity.Id;
        }
    }
}
