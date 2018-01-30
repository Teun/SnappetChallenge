using System.Collections.Generic;
using FlashMapper;
using FlashMapper.DependencyInjection;

namespace SnappetChallenge.Infrastructure
{
    public class FlashMapperInitializer : IInitializer
    {
        private readonly IFlashMapperBuildersRegistrationService registrationService;
        private readonly IEnumerable<IFlashMapperBuilder> flashMapperBuilders;

        public FlashMapperInitializer(IFlashMapperBuildersRegistrationService registrationService,
            IEnumerable<IFlashMapperBuilder> flashMapperBuilders)
        {
            this.registrationService = registrationService;
            this.flashMapperBuilders = flashMapperBuilders;
        }

        public void Init()
        {
            registrationService.RegisterAllBuilders();
        }
    }
}