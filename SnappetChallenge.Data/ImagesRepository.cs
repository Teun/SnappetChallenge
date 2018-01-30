using System.Linq;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Data
{
    public class ImagesRepository : IImagesRepository
    {
        public IQueryable<ImageDb> Query()
        {
            return new[]
            {
                new ImageDb
                {
                    ImageId = 1,
                    ImageUrl = "/images/mockphoto.png"
                }
            }.AsQueryable();
        }
    }
}