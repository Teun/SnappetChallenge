using AutoMapper;
using SchoolMaster.Database.QueryModels;
using SchoolMaster.Models;
using SchoolMaster.Models.DataTransferObjects;

namespace SchoolMaster.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(u => u.FullName, opt => opt.MapFrom(m => $"{m.Firstname.Trim()} {m.LastName.Trim()}"));

            CreateMap<SubmissionCount, SubmissionCountDto>();
        }
    }
}