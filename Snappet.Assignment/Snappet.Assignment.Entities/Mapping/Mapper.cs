using AutoMapper;
using Snappet.Assignment.Entities.DomainObjects;
using Snappet.Assignment.Entities.DTOs;

namespace Snappet.Assignment.Entities.Mapping
{
    public class Mapper : Interfaces.IMapper
    {
        readonly MapperConfiguration config;
        public Mapper()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Exercise, ExerciseDto>();
                cfg.CreateMap<Work, WorkDto>();


            });
        }



        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapper = config.CreateMapper();
            return mapper.Map<TSource, TDestination>(source);
        }


    }
}
