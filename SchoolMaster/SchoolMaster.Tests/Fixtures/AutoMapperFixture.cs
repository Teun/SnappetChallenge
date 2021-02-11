using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SchoolMaster.Configurations;

namespace SchoolMaster.Tests.Fixtures
{
    public class AutoMapperFixture
    {
        public IMapper Mapper { get; private set; }

        public AutoMapperFixture()
        {
            Setup();
        }

        public void Setup()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg
                => cfg.AddProfile<MappingProfile>())
            );
        }
    }
}
