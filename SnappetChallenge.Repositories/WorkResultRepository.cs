using Core.Interfaces.Repositories;
using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Repositories.JSON
{
    public class WorkResultRepository : IWorkResultRepository
    {
        readonly List<WorkResult> _items;

        public WorkResultRepository()
        {
            using (StreamReader r = new StreamReader(ConfigurationManager.AppSettings["DataFilePath"]))
            {
                var jsonWorkResult = r.ReadToEnd();
                _items = JsonConvert.DeserializeObject<List<WorkResult>>(jsonWorkResult);
            }
        }

        public List<string> GetLearningObjectivesBySubjectAndDomain(string subject, string domain)
        {
            return _items.Where(i => i.Subject == subject && i.Domain == domain).Select(i => i.LearningObjective).Distinct().ToList();
        }

        public List<string> GetDomainsBySubject(string subject)
        {
            return _items.Where(i => i.Subject == subject).Select(i => i.Domain).Distinct().ToList();
        }

        public List<string> GetAllSubjects()
        {
            return _items.Select(i => i.Subject).Distinct().ToList();
        }

        public List<WorkResult> SearchWorkResults(DateTime? startDateTime,
        DateTime? endDateTime,
            bool? Correct,
            int? Progress,
            int? UserId,
            int? ExerciseId,
            string Subject,
            string Domain,
            string LearningObjective)
        {

            var resultList = _items;

            if (startDateTime.HasValue)
                resultList = resultList.Where(r => r.SubmitDateTime >= startDateTime.Value).ToList();

            if (endDateTime.HasValue)
                resultList = resultList.Where(r => r.SubmitDateTime <= endDateTime.Value).ToList();

            if (Correct.HasValue)
                resultList = resultList.Where(r => r.Correct == Correct.Value).ToList();

            if (Progress.HasValue)
                resultList = resultList.Where(r => r.Progress == Progress.Value).ToList();

            if (UserId.HasValue)
                resultList = resultList.Where(r => r.UserId == UserId.Value).ToList();

            if (ExerciseId.HasValue)
                resultList = resultList.Where(r => r.ExerciseId == ExerciseId.Value).ToList();

            if (!string.IsNullOrEmpty(Subject))
                resultList = resultList.Where(r => r.Subject.Contains(Subject)).ToList();

            if (!string.IsNullOrEmpty(Domain))
                resultList = resultList.Where(r => r.Domain.Contains(Domain)).ToList();

            if (!string.IsNullOrEmpty(LearningObjective))
                resultList = resultList.Where(r => r.LearningObjective.Contains(LearningObjective)).ToList();

            return resultList;
        }

        public List<string> GetAllStudents()
        {
            return _items.OrderBy(x => x.UserId).Select(i => i.UserId.ToString()).Distinct().ToList();
        }

        public List<string> GetAllDomains()
        {
            return _items.OrderBy(i => i.Domain).Select(i => i.Domain).Distinct().ToList();
        }

        public List<string> GetAllLearningObjectives()
        {
            return _items.OrderBy(i => i.LearningObjective).Select(i => i.LearningObjective).Distinct().ToList();
        }


        public void Delete(IEnumerable<WorkResult> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(WorkResult entity)
        {
            throw new NotImplementedException();
        }



        public WorkResult GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<WorkResult> entities)
        {
            throw new NotImplementedException();
        }

        public void Insert(WorkResult entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<WorkResult> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkResult entity)
        {
            throw new NotImplementedException();
        }


    }
}
