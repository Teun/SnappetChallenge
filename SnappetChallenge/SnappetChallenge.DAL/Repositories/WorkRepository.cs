using Newtonsoft.Json;
using SnappetChallenge.DAL.Data;
using SnappetChallenge.DAL.Repositories.Contracts;
using SnappetChallenge.DAL.Repositories.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SnappetChallenge.DAL.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private IQueryable<Work> _work;

        private WorkRepository(IQueryable<Work> workdata)
        {
            _work = workdata;
        }

        public static WorkRepository LoadData()
        {
            return LoadData(SnappetDal.Default.DefaultWorkJsonpath);
        }

        public static WorkRepository LoadData(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(path);
            }
            if (!File.Exists(path))
            {
                throw new NoWorkFileException($"Supplied path does not resolve to a file \"{path}\"");
            }
            var data = JsonConvert.DeserializeObject<List<Work>>(Regex.Replace(File.ReadAllText(path),"\"NULL\"","null"));
            return new WorkRepository(data.AsQueryable());
        }

        public IEnumerable<Work> GetByDate(DateTime fromDate, DateTime toDate)
        {
            if(toDate < fromDate)
            {
                throw new ArgumentOutOfRangeException("toDate cannot be smaller than fromDate");
            }
            return _work.Where(w => w.SubmitDateTime >= fromDate && w.SubmitDateTime <= toDate);
        }
    }
}
