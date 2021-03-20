using SnappetChallenge.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnappetChallenge.Repository.Interfaces
{
    public interface IFileDataLoader
    {
        Task<TResult> LoadFromFile<TModel, TResult>(string relativePath);
    }
}
