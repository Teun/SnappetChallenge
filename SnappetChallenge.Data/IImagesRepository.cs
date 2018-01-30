using System.Linq;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Data
{
    public interface IImagesRepository
    {
        IQueryable<ImageDb> Query();
    }
}