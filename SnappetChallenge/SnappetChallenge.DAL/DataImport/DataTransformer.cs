namespace SnappetChallenge.DAL.DataImport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Entities;
    
    /// <summary>
    /// TODO keep it DRY
    /// </summary>
    internal sealed class DataTransformer
    {
        private readonly SnappetChallengeContext _context;

        private List<Domain> domains;
        private List<Student> students;
        private List<Exercise> exercises;
        private List<Subject> subjects;
        private List<Objective> objectives;

        public DataTransformer(SnappetChallengeContext context)
        {
           _context = context;
            domains = new List<Domain>();
            students = new List<Student>();
            exercises = new List<Exercise>();
            subjects = new List<Subject>();
            objectives = new List<Objective>();
        }

        public void PerformTransformation()
        {
            GetStudents();
            GetDomains();
            GetObjectives();
            GetSubjects();
            GetExercises();
            GetAnswers();
        }

        //private List<T> GetDistinctList<T>(Expression<Func<StudentAnswer>> predicate) where T : BaseEntity
        //{
        //    return _context.StudentAnswers.Select<T>(predicate).Distinct();
        //}


        private void GetStudents()
        {
            var uniqueListOfStudents = _context.StudentAnswers.Select(s => s.UserId).Distinct();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var studentId in uniqueListOfStudents)
            {
                var generatedStudent = new Student
                {
                    SourceId = studentId,
                    Name = RandomNameGenerator.GetName()
                };
                students.Add(generatedStudent);
            }
            _context.Students.AddRange(students);
            _context.SaveChanges();
        }

        private void GetDomains()
        {
            var uniqueListOfDomains =
                 _context.StudentAnswers.Select(s =>s.Domain).Distinct();
            
            foreach (var domain in uniqueListOfDomains)
            {
                var generatedDomain = new Domain
                {
                    DateAdded = DateTime.Now,
                    DomainName = domain
                };
                
                domains.Add(generatedDomain);
            }
            _context.Domains.AddRange(domains);
            _context.SaveChanges();
            
        }

        private void GetObjectives()
        {
            var uniqueListOfObjectives =
                 _context.StudentAnswers.Select(s => s.LearningObjective).Distinct();

            foreach (var objective in uniqueListOfObjectives)
            {
                var genereatedObjective = new Objective
                {
                    DateAdded = DateTime.Now,
                    LearningObjective = objective
                };

                objectives.Add(genereatedObjective);
            }
            _context.Objectives.AddRange(objectives);
            _context.SaveChanges();

        }

        private void GetSubjects()
        {
            var uniqueListOfSubjects =
                 _context.StudentAnswers.Select(s => s.Subject).Distinct();

            foreach (var subject in uniqueListOfSubjects)
            {
                var generatedsSubject  = new Subject
                {
                    DateAdded = DateTime.Now,
                    SubjectName = subject
                };
                subjects.Add(generatedsSubject);
            }
            _context.Subjects.AddRange(subjects);
            _context.SaveChanges();
        }


        private void GetExercises()
        {
            var uniqueListOfExercises = 
                _context.StudentAnswers.Select(s => 
                    new { s.ExerciseId, s.Domain, s.Subject, s.Difficulty, s.LearningObjective }).Distinct();

            foreach (var exercise in uniqueListOfExercises)
            {
                var generatedExercise = new Exercise
                {
                    DateAdded = DateTime.Now,
                    Difficulty = exercise.Difficulty ?? 0,
                    Domain = domains.SingleOrDefault(d=>d.DomainName == exercise.Domain),
                    Objective = objectives.SingleOrDefault(o=>o.LearningObjective == exercise.LearningObjective),
                    SourceId = exercise.ExerciseId,
                    Subject = subjects.SingleOrDefault(s=>s.SubjectName == exercise.Subject)
                };
                exercises.Add(generatedExercise);
            }

            _context.Exercises.AddRange(exercises);
            _context.SaveChanges();
        }

        private void GetAnswers()
        {
            var uniqueListOfAnswers =
                _context.StudentAnswers.Select(s =>
                    new { s.ExerciseId, s.UserId, s.Correct, s.SubmitDateTime, s.SubmittedAnswerId, s.Progress }).Distinct();

            var totalAnswers = uniqueListOfAnswers.Count();
            var batchSize = 1000;
            var totalBatches = Math.Ceiling((double)totalAnswers/batchSize);

            for (var batch = 0; batch < totalBatches; batch++)
            {
                var answers = new List<Answer>();

                foreach (var answer in uniqueListOfAnswers.OrderBy(a=>a.SubmittedAnswerId).Skip(batch * batchSize).Take(batchSize))
                {
                    var generatedAnswer = new Answer
                    {
                        DateAdded = DateTime.Now,
                        Correct = answer.Correct,
                        Exercise = exercises.SingleOrDefault(e => e.SourceId == answer.ExerciseId),
                        Progress = answer.Progress,
                        SourceId = answer.SubmittedAnswerId,
                        Student = students.SingleOrDefault(s=>s.SourceId == answer.UserId),
                        SubmitDateTime = answer.SubmitDateTime
                    };
                    answers.Add(generatedAnswer);
                }
                _context.Answers.AddRange(answers);
                _context.SaveChanges();
            }
        }
    }
}
