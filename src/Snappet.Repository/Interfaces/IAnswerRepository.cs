using Snappet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Repository.Interfaces
{
    public interface IAnswerRepository : IRepository
    {
        void Add(Answer item);
        IEnumerable<Answer> GetAll();
        Answer Find(int ID);
        void Remove(int ID);
        Answer Update(Answer item);
    }
}
