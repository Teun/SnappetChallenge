using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Snappet.Entity;
using Snappet.Model;
using Snappet.Repository;
using Snappet.Repository.AutoComplete;

namespace Snappet.Service
{
    public class PrepareDataService : IHostedService
    {
        private readonly UserAutoCompleteRepository _userAutoCompleteRepository;
        private readonly DomainAutoCompleteRepository _domainAutoCompleteRepository;
        private readonly ExerciseAutoCompleteRepository _exerciseAutoCompleteRepository;
        private readonly LearningObjectiveAutoCompleteRepository _learningObjectiveAutoCompleteRepository;
        private readonly SubjectAutoCompleteRepository _subjectAutoCompleteRepository;
        private readonly ISubmittedAnswerRepository _submittedAnswerRepository;

        public PrepareDataService(UserAutoCompleteRepository userAutoCompleteRepository,
            DomainAutoCompleteRepository domainAutoCompleteRepository,
            ExerciseAutoCompleteRepository exerciseAutoCompleteRepository,
            LearningObjectiveAutoCompleteRepository learningObjectiveAutoCompleteRepository,
            SubjectAutoCompleteRepository subjectAutoCompleteRepository,
            ISubmittedAnswerRepository submittedAnswerRepository)
        {
            _userAutoCompleteRepository = userAutoCompleteRepository;
            _domainAutoCompleteRepository = domainAutoCompleteRepository;
            _exerciseAutoCompleteRepository = exerciseAutoCompleteRepository;
            _learningObjectiveAutoCompleteRepository = learningObjectiveAutoCompleteRepository;
            _subjectAutoCompleteRepository = subjectAutoCompleteRepository;
            _submittedAnswerRepository = submittedAnswerRepository;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var streamReader = new StreamReader("./data.json");
            var json = await streamReader.ReadToEndAsync();

            var items = JsonConvert.DeserializeObject<Data[]>(json);

            if (items == null)
                throw new ApplicationException("No data to load the application");

            var submittedAnswers = items.Select(x => new SubmittedAnswer
            {
                Correct = (CorrectState) x.Correct,
                Difficulty = x.Difficulty == "NULL" ? null : double.Parse(x.Difficulty),
                Domain = new Domain
                {
                    Name = x.Domain
                },
                Exercise = new Exercise
                {
                    Id = x.ExerciseId
                },
                Progress = (ProgressState) x.Progress,
                Subject = new Subject
                {
                    Name = x.Subject
                },
                User = new User
                {
                    Id = x.UserId
                },
                LearningObjective = new LearningObjective
                {
                    Name = x.LearningObjective
                },
                SubmitDateTime = DateTime.Parse(x.SubmitDateTime),
                SubmittedAnswerId = x.SubmittedAnswerId
            });
            await _submittedAnswerRepository.SetData(submittedAnswers);

            var users = items.GroupBy(x => x.UserId).Select(x => new User {Id = x.Key});
            await _userAutoCompleteRepository.SetData(users);

            var domains = items.GroupBy(x => x.Domain).Select(x => new Domain {Name = x.Key});
            await _domainAutoCompleteRepository.SetData(domains);

            var exercises = items.GroupBy(x => x.ExerciseId).Select(x => new Exercise {Id = x.Key});
            await _exerciseAutoCompleteRepository.SetData(exercises);

            var learningObjectives = items.GroupBy(x => x.LearningObjective)
                .Select(x => new LearningObjective {Name = x.Key});
            await _learningObjectiveAutoCompleteRepository.SetData(learningObjectives);

            var subjects = items.GroupBy(x => x.Subject).Select(x => new Subject {Name = x.Key});
            await _subjectAutoCompleteRepository.SetData(subjects);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}