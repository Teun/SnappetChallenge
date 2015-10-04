using System.Collections.Generic;
using Snappet.Domain.Mappers;
using System.Linq;
using Snappet.DataAccess;
using Snappet.Domain.Contracts;

namespace Snappet.Domain
{
    public interface IExerciseResultService {
        List<ExerciseResult> Get();
        void SaveExerciseResults(List<ExerciseResult> exerciseResults);
        void DeleteAllData();
        void SaveRelatedData(List<ExerciseResult> contracts);
        List<Contracts.LearningObjective> GetLearningObjectives();
        List<Contracts.Domain> GetDomains();
        List<Contracts.Subject> GetSubjects();
        List<ExerciseResult> GetExerciseResults(DataTableSearch search);
        int GetExerciseResultCount(int domainId, int userId,string searchtext);
        List<User> GetUsers(int domainId);
    }

    public class ExerciseResultService : IExerciseResultService
    {
        private readonly IExerciseResultRepository _exerciseResultRepository;
        private readonly IDomainRepository _domainRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILearningObjectiveRepository _learningObjectiveRepository;
        private readonly IExerciseResultMapper _exerciseResultMapper;
        private readonly IRelatedDataMapper _relatedDataMapper;
        private readonly IUserMapper _userMapper;

        public ExerciseResultService(IExerciseResultRepository exerciseResultRepository,
           IExerciseResultMapper exerciseResultMapper, ILearningObjectiveRepository learningObjectiveRepository, ISubjectRepository subjectRepository, IDomainRepository domainRepository, IRelatedDataMapper relatedDataMapper, IUserMapper userMapper) {
            _exerciseResultRepository = exerciseResultRepository;
            _exerciseResultMapper = exerciseResultMapper;
            _learningObjectiveRepository = learningObjectiveRepository;
            _subjectRepository = subjectRepository;
            _domainRepository = domainRepository;
            _relatedDataMapper = relatedDataMapper;
            _userMapper = userMapper;
           }
        public List<ExerciseResult> Get()
        {
            var results = _exerciseResultRepository.GetByDate();
            return results.Select(x=> _exerciseResultMapper.Map(x)).ToList();
        }

        public List<ExerciseResult> GetExerciseResults(DataTableSearch search)
        {
            var results = _exerciseResultRepository.GetExerciseResults(search.DomainId,search.UserId,search.Page, search.Length, search.Search,
                search.Order.ColumnName, search.Order.Order);
            var result = results.Select(x=>_exerciseResultMapper.Map(x));
            return result.ToList();
        }

        public List<User> GetUsers(int domainId)
        {
            var results = _exerciseResultRepository.GetUsers(domainId);
            return _userMapper.Map(results);
        }



        public int GetExerciseResultCount(int domainId, int userId, string searchtext)
        {
            return _exerciseResultRepository.GetExerciseResultsCount(domainId,userId, searchtext);
        }

        public void DeleteAllData()
        {
            _exerciseResultRepository.DeleteAll();
            _subjectRepository.DeleteAll();
            _domainRepository.DeleteAll();
            _learningObjectiveRepository.DeleteAll();
        }

        public void SaveRelatedData(List<ExerciseResult> contracts)
        {
            var subjects = contracts.Select(x => x.Subject).Distinct();
            _subjectRepository.Save(subjects.ToList());

            var domains = contracts.Select(x => x.Domain).Distinct();
            _domainRepository.Save(domains.ToList());

            var learningObjectives = contracts.Select(x => x.LearningObjective).Distinct();
            _learningObjectiveRepository.Save(learningObjectives.ToList());
        }

        public List<Contracts.Subject> GetSubjects()
        {
            var domainEntities = _subjectRepository.GetAll();
            return domainEntities.Select(x => _relatedDataMapper.Map(x)).ToList();
        }
        public List<Contracts.Domain> GetDomains()
        {
            var domainEntities = _domainRepository.GetAll();
            return domainEntities.Select(x => _relatedDataMapper.Map(x)).ToList();
        }
        public List<Contracts.LearningObjective> GetLearningObjectives()
        {
            var domainEntities = _learningObjectiveRepository.GetAll();
            return domainEntities.Select(x => _relatedDataMapper.Map(x)).ToList();
        }


        public void SaveExerciseResults(List<ExerciseResult> exerciseResults)
        {
            var exerciseResultEntities = exerciseResults.Select(x => _exerciseResultMapper.Map(x)).ToList();
            _exerciseResultRepository.Save(exerciseResultEntities);
        }
    }
}
