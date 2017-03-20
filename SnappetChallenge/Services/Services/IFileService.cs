using System.IO;

namespace Services.Services
{
    public interface IFileService
    {
        TextReader GetTextReader(string path);
    }
}
