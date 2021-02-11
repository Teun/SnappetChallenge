using AutoMapper;
using SchoolMaster.Configurations;

namespace SchoolMaster.Tests.Fixtures
{
    public class AutoMapperFixture
    {
        public AutoMapperFixture()
        {
            Setup();
        }

        public IMapper Mapper { get; private set; }
        public MapperConfiguration MapperConfiguration { get; private set; }

        public void Setup()
        {
            MapperConfiguration = new MapperConfiguration(cfg
                => cfg.AddProfile<MappingProfile>());

            Mapper = new Mapper(MapperConfiguration);
        }
    }
}