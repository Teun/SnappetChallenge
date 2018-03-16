using Nicollas.Core;
using Nicollas.Core.Entities;
using Nicollas.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nicollas.Imp.Factory
{
    public class SubjectFactory : Factory<Subject, int>, ISubjectFactory
    {
        public SubjectFactory(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        public async Task<int> GetSubjectId(Subject subject)
        {
            var entity = this.Repository.FindByCriteria(row => row.Description.Equals(subject.Description));
            if(entity == null)
            {
                this.Repository.Add(subject);
                await this.UnitOfWork.CommitAsync();
                return subject.Id;
            }

            return entity.Id;
        }
    }
}
