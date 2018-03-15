using Nicollas.Core;
using Nicollas.Core.Entities;
using Nicollas.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nicollas.Imp.Factory
{
    public class SubjectFactory : Factory<Subject, int>, ISubjectFactory
    {
        public SubjectFactory(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }
    }
}
