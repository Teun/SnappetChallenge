using LiteDB;
using Microsoft.Extensions.Options;
using SnappetDomain.Models;
using SnappetDomain.Options;
using SnappetDomain.Repositories;
using SnappetRepository.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SnappetRepository.Repositories
{
    public class SnappetRepository : ISnappetRepository
    {
        private readonly ISnappetRepositorySeeder _seeder;
        private readonly IOptions<SnappetRepositoryOptions> _options;
        private LiteDatabase _repository;
        private LiteCollection<LearningData> _learningDataCollection;

        public SnappetRepository(   ISnappetRepositorySeeder seeder, 
                                    IOptions<SnappetRepositoryOptions> options)
        {
            _seeder = seeder;
            _options = options;
            SeedRepository();
        }

        private void SeedRepository()
        {
            try
            {
                InitRepository();
                if(_learningDataCollection.Count() == 0)
                {
                    _learningDataCollection.InsertBulk(_seeder.ReadLearningData());
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void InitRepository()
        {
            _repository = new LiteDatabase(_options?.Value.RepositoryPath);
            _learningDataCollection = _repository.GetCollection<LearningData>();
        }

        public IEnumerable<LearningSubject> GetLearningDataByDate(DateTime maxDateTime)
        {
            var groups = _learningDataCollection.Find(l => l.SubmitDateTime >= maxDateTime.Date && l.SubmitDateTime <= maxDateTime)
                .GroupBy(d => new { d.Subject, d.Domain, d.LearningObjective })
                .GroupBy(d => new { d.Key.Subject, d.Key.Domain })
                .GroupBy(d => d.Key.Subject).ToList();

            var subjects = new List<LearningSubject>();
            foreach(var subjectGroup in groups)
            {
                var subject = new LearningSubject { Name = subjectGroup.Key, Domains = new List<LearningDomain>() };
                foreach(var domainGroup in subjectGroup)
                {
                    var domain = new LearningDomain { Name = domainGroup.Key.Domain, Objectives = new List<LearningObjectiveData>() };
                    foreach (var objectiveGroup in domainGroup)
                    {
                        domain.Objectives.Add(new LearningObjectiveData
                        {
                            Name = objectiveGroup.Key.LearningObjective,
                            LearningData = objectiveGroup.ToList(),
                            AverageProgress = Math.Round(objectiveGroup.Where(d => d.Progress != 0).Average(d => d.Progress), 2),
                            NumberOfExercises = objectiveGroup.GroupBy(d => d.SubmittedAnswerId).Count(),
                            NumberOfPupils = objectiveGroup.GroupBy(d => d.UserId).Count()
                        });
                    }
                    subject.Domains.Add(domain);
                }
                subjects.Add(subject);
            }
            return subjects;
        }
    }   
}
