using AutoMapper;
using SnappetChallenge.Core.Entities;
using SnappetChallenge.Infrastructure.Models;

namespace SnappetChallenge.Infrastructure.AutoMapper
{
    public class EntitiesToDTOProfile : Profile
    {
        public EntitiesToDTOProfile()
        {
            CreateMap<Works, WorksDTO>();
            CreateMap<Subjects, SubjectsDTO>();
            CreateMap<Subject, SubjectDTO>();
            CreateMap<Student, StudentDTO>();
            CreateMap<LearningObjective, LearningObjectiveDTO>();
            CreateMap<Exercises, ExercisesDTO>();
            CreateMap<Exercise, ExerciseDTO>();
            CreateMap<Domain, DomainDTO>();
            CreateMap<Answers, AnswersDTO>();
            CreateMap<Answer, AnswerDTO>();
        }
    }
}
