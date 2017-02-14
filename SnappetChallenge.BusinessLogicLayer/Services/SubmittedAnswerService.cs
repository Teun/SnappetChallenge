using System;
using System.Collections.Generic;
using System.Linq;
using SnappetChallenge.BusinessLogicLayer.BusinessObjects;
using SnappetChallenge.BusinessLogicLayer.Interfaces;
using SnappetChallenge.DataAccessLayer.DTO;
using SnappetChallenge.DataAccessLayer.Interfaces;

namespace SnappetChallenge.BusinessLogicLayer.Services
{
    public class SubmittedAnswerService : ISubmittedAnswerService
    {
        private readonly ISubmittedAnswerRepository _submittedAnswerRepository;
        private readonly ISubmittedAnswerMapper _submittedAnswerMapper;

        private readonly DateTime _fakeToday = new DateTime(2015, 3, 24, 11, 30, 0, DateTimeKind.Utc);

        public SubmittedAnswerService(ISubmittedAnswerRepository submittedAnswerRepository, ISubmittedAnswerMapper submittedAnswerMapper)
        {
            if (submittedAnswerRepository == null) throw new ArgumentNullException(nameof(submittedAnswerRepository));
            if (submittedAnswerMapper == null) throw new ArgumentNullException(nameof(submittedAnswerMapper));

            _submittedAnswerRepository = submittedAnswerRepository;
            _submittedAnswerMapper = submittedAnswerMapper;
        }

        public IQueryable<SubmittedAnswerDto> GetAllForTodayAndBefore()
        {
            return _submittedAnswerRepository.GetAll().Where(x => x.SubmitDateTime <= _fakeToday);
        }

        // TODO: take care about paging via Take and Skip if it would be time left
        public List<SubmittedAnswer> GetSubmittedAnswers()
        {
            var submittedAnswerList = GetAllForTodayAndBefore().Where(x => x.SubmitDateTime <= _fakeToday);
            return _submittedAnswerMapper.Map(submittedAnswerList);
        }

        public TopStudentStatistic GetTopStudentStatistic(int count, string subject)
        {
            var topStudentsList = GetTopProgressBySubject(count, subject);
            var bottomStudentsList = GetBottomProgressBySubject(count, subject);

            return new TopStudentStatistic
            {
                Subject = subject,
                TopStudentList = topStudentsList,
                BottomStudentList = bottomStudentsList
            };
        }

        public List<SubmittedAnswer> GetByUserId(long userId)
        {
            var submittedAnswerDtoList = GetAllForTodayAndBefore()
                .Where(x => x.UserId == userId)
                .ToList();
            return _submittedAnswerMapper.Map(submittedAnswerDtoList);
        }

        public List<SubmittedAnswer> GetForPeriod(DateTime from, DateTime to, bool includeFrom = true, bool includeTo = true)
        {
            var answersQuery = _submittedAnswerRepository.GetAll();
            answersQuery = includeFrom
                ? answersQuery.Where(x => from >= x.SubmitDateTime)
                : answersQuery.Where(x => from > x.SubmitDateTime);
            answersQuery = includeTo
                ? answersQuery.Where(x => to <= x.SubmitDateTime)
                : answersQuery.Where(x => to < x.SubmitDateTime);
            var submittedAnswerDtoList = answersQuery.ToList();
            return _submittedAnswerMapper.Map(submittedAnswerDtoList);
        }

        public List<SubmittedAnswer> GetForPeriodInclude(DateTime @from, DateTime to)
        {
            var submittedAnswerDtoList = _submittedAnswerRepository.GetAll()
                .Where(x => x.SubmitDateTime >= from && x.SubmitDateTime <= to)
                .ToList();
            return _submittedAnswerMapper.Map(submittedAnswerDtoList);
        }

        public List<SubmittedAnswer> GetForPeriodExclude(DateTime @from, DateTime to)
        {
            var submittedAnswerDtoList = _submittedAnswerRepository.GetAll()
                .Where(x => x.SubmitDateTime > from && x.SubmitDateTime < to)
                .ToList();
            return _submittedAnswerMapper.Map(submittedAnswerDtoList);
        }

        public Dictionary<long, int> GetTopProgressBySubject(int count, string subject)
        {
            var topStudentsByProgressSum = GetAllForTodayAndBefore()
                .Where(x => x.Subject.ToLower() == subject.ToLower())
                .GroupBy(
                    x => x.UserId,
                    y => y.Progress,
                    (userId, progressList) => new
                    {
                        UserId = userId,
                        ProgressSum = progressList.Sum()
                    })
                .OrderByDescending(x => x.ProgressSum)
                .Take(count)
                .ToDictionary(x => x.UserId, y => y.ProgressSum);
            return topStudentsByProgressSum;
        }

        public Dictionary<long, int> GetBottomProgressBySubject(int count, string subject)
        {
            var bottomStudentsByProgressSum = GetAllForTodayAndBefore()
                .Where(x => x.Subject.ToLower() == subject.ToLower())
                .GroupBy(
                    x => x.UserId,
                    y => y.Progress,
                    (userId, progressList) => new
                    {
                        UserId = userId,
                        ProgressSum = progressList.Sum()
                    })
                .OrderBy(x => x.ProgressSum)
                .Take(count)
                .ToDictionary(x => x.UserId, y => y.ProgressSum);
            return bottomStudentsByProgressSum;
        }


        public List<SubmittedAnswer> GetWrongAnswers(long userId, string subject, string domain, string learningObjective)
        {
            var userWrongAnswersQuery = GetAllForTodayAndBefore();

            // sql injections will be handled via EF parameterization in case of db solution
            if (subject != null)
            {
                userWrongAnswersQuery = userWrongAnswersQuery.Where(x => x.Subject == subject);
            }
            if (domain != null)
            {
                userWrongAnswersQuery = userWrongAnswersQuery.Where(x => x.Domain == domain);
            }
            if (learningObjective != null)
            {
                userWrongAnswersQuery = userWrongAnswersQuery.Where(x => x.LearningObjective == learningObjective);
            }

            var submittedAnswerDtoList = userWrongAnswersQuery.ToList();
            return _submittedAnswerMapper.Map(submittedAnswerDtoList);
        }
    }
}
