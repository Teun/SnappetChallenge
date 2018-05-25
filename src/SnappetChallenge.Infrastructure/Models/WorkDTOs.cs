using System;
using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.Infrastructure.Models
{
    public class WorksDTO
    {
        public IEnumerable<StudentDTO> Students { get; set; }

        public int TotalCorrect { get; set; }
        public int TotalIncorrect { get; set; }
        public decimal CorrectnessAverage { get; set; }

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

        public int TotalCorrect { get; set; }
        public int TotalIncorrect { get; set; }
        public decimal CorrectnessAverage { get; set; }
        public decimal AverageDifficulty { get; set; }
        public double AverageProgress { get; set; }

        public SubjectsDTO Subjects { get; set; }
    }

    public class ExerciseDTO
    {
        public int Id { get; set; }
        public AnswersDTO Answers { get; set; }

        public decimal Difficulty { get; set; }
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

        public int Total { get; set; }
        public int TotalCorrect { get; set; }
        public int TotalIncorrect { get; set; }
        public decimal CorrectnessAverage { get; set; }
        public double AverageProgress { get; set; }
    }

    public class AnswerDTO
    {
        public int Id { get; set; }
        public DateTime Submitted { get; set; }
        public bool IsCorrect { get; set; }
        public int Progress { get; set; }
    }
}
