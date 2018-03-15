using Nicollas.Core;
using Nicollas.Core.Entities;
using Nicollas.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nicollas.Imp.Factory
{
    public class DomainFactory : Factory<Domain, int>, IDomainFactory
    {
        public DomainFactory(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }
    }
}
