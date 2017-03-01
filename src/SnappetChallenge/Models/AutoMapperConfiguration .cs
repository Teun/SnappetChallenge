using AutoMapper;
using SnappetChallenge.Models.ViewModels;

namespace SnappetChallenge.Models
{
    public class AutoMapperProfileConfiguration:Profile
    {
        public AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<Subject, SubjectFilter>().ReverseMap();
            CreateMap<Domain, DomainFilter>().ReverseMap();
            CreateMap<LearningObjective, LearningObjectiveFilter>().ReverseMap();
        }
    }
}
