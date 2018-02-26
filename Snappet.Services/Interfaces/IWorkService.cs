using System.Data;
using Snappet.Core.Utils;

namespace Snappet.Services.Interfaces
{
    public interface IWorkService
    {
        DataTable LoadAndDataFile(string filePath = ApplicationConstants.WorkFilePath,
            char delimiter = ApplicationConstants.FileDelimiter);

    }
}
