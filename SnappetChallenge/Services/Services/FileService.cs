using System;
using System.IO;

namespace Services.Services
{
    public class FileService : IFileService
    {
        public TextReader GetTextReader(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            return new StreamReader(File.OpenRead(path));
        }
    }
}
