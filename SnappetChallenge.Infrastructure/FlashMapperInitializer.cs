using System.Collections.Generic;
using FlashMapper;
using FlashMapper.DependencyInjection;

namespace SnappetChallenge.Infrastructure
{
    public class FlashMapperInitializer : IInitializer
    {
        private readonly IFlashMapperBuildersRegistrationService registrationService;

        public FlashMapperInitializer(IFlashMapperBuildersRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        public void Init()
        {
            registrationService.RegisterAllBuilders();
        }
    }
}