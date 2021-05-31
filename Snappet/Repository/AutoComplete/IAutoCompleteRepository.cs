using System.Collections.Generic;
using System.Threading.Tasks;
using Snappet.Entity;

namespace Snappet.Repository.AutoComplete
{
    public delegate IAutoCompleteRepository AutoCompleteRepositoryResolver(AutoCompleteType type);

    public interface IAutoCompleteRepository
    {
        Task<ICollection<AutoCompleteItem>> AutoComplete(string input, int count);
    }
}