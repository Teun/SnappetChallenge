using System.Linq;
using SnappetChallenge.Core.Builders;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Data;

namespace SnappetChallenge.Core
{
    public class ImageProvider : IImageProvider
    {
        private readonly IImagesRepository imagesRepository;
        private readonly IImageBuilder imageBuilder;

        public ImageProvider(IImagesRepository imagesRepository,
            IImageBuilder imageBuilder)
        {
            this.imagesRepository = imagesRepository;
            this.imageBuilder = imageBuilder;
        }

        public Image FindImage(int imageId)
        {
            var image = imagesRepository
                .Query()
                .FirstOrDefault(i => i.ImageId == imageId);
            if (image == null)
                return null;
            return imageBuilder.Build(image);
        }
    }
}