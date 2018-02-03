using FlashMapper;
using FlashMapper.DependencyInjection;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Core.Builders
{
    public class ImageBuilder : FlashMapperBuilder<ImageDb, Image, ImageBuilder>, IImageBuilder
    {
        public ImageBuilder(IMappingConfiguration mappingConfiguration) : base(mappingConfiguration)
        {
        }

        protected override void ConfigureMapping(IFlashMapperBuilderConfigurator<ImageDb, Image> configurator)
        {
            configurator.CreateMapping(i => new Image());
        }
    }
}