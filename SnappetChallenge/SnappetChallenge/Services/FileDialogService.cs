using Microsoft.Win32;

namespace SnappetChallenge.Services
{
    public class FileDialogService : IFileDialogService
    {
        public string OpenFileDialog(string filter = "")
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = filter,
            };

            bool? result = openFileDialog.ShowDialog();
            return result == true ? openFileDialog.FileName : string.Empty;
        }
    }
}