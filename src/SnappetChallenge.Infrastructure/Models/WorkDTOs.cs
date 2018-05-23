using System;
using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.Infrastructure.Models
{
    public class WorksDTO
    {
        public IEnumerable<StudentDTO> Students { get; set; }

        public int TotalCorrect => Students.Sum(x => x.Exercises.TotalCorrect);
        public int TotalIncorrect => Students.Sum(x => x.Exercises.TotalIncorrect);
        public decimal CorrectnessAverage => Students.Average(x => x.Exercises.CorrectnessAverage);

        public SubjectsDTO Subjects { get; set; }
    }

    public class SubjectsDTO
    {
        public IList<SubjectDTO> All { get; set; }
    }

    public class SubjectDTO
    {
        public string Name { get; set; }
        public IList<DomainDTO> Domains { get; set; }
    }

    public class StudentDTO
    {
        public int Id { get; set; }

        public ExercisesDTO Exercises { get; set; }
    }

    public class LearningObjectiveDTO
    {
        public string Name { get; set; }
    }

    public class ExercisesDTO
    {
        public IEnumerable<ExerciseDTO> All { get; set; }

        public int TotalCorrect => All.Sum(x => x.Answers.TotalCorrect);
        public int TotalIncorrect => All.Sum(x => x.Answers.TotalIncorrect);
        public decimal CorrectnessAverage => All.Average(x => x.Answers.CorrectnessAverage);

        public SubjectsDTO Subjects { get; set; }
    }

    public class ExerciseDTO
    {
        public int Id { get; set; }
        public AnswersDTO Answers { get; set; }

        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }

    public class DomainDTO
    {
        public string Name { get; set; }
        public IList<LearningObjectiveDTO> LearningObjectives { get; set; }
    }

    public class AnswersDTO
    {
        public IEnumerable<AnswerDTO> All { get; set; }

        public int Total => All.Count();
        public int TotalCorrect => All.Count(x => x.IsCorrect);
        public int TotalIncorrect => Total - TotalCorrect;
        public decimal CorrectnessAverage => (100 * TotalCorrect) / Total;
    }

    public class AnswerDTO
    {
        public int Id { get; set; }
        public DateTime Submitted { get; set; }
        public bool IsCorrect { get; set; }
        public int Progress { get; set; }
    }
}
