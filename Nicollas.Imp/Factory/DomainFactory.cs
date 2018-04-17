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

        public async Task<Domain> GetDomain(string description)
        {
            var entity = this.Repository.FindByCriteria(row => row.Description.Equals(description));
            if (entity == null)
            {
                entity = new Domain { Description = description };
                this.Repository.Add(entity);
                await this.UnitOfWork.CommitAsync();
            }

            return entity;
        }
    }
}
