using Nicollas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nicollas.Core.Factories
{
    public interface ISubjectFactory : IFactory<Subject, int>
    {
        Task<int> GetSubjectId(Subject subject);
    }
}
