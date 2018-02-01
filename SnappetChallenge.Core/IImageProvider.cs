using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public interface IImageProvider
    {
        Image FindImage(int imageId);
    }
}