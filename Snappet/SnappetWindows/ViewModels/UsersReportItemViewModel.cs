using BlCore.ReportServices.Models;

namespace Windows.ViewModels
{
    public class UsersReportItemViewModel : ViewModelBase
    {
        private UsersReportItem _source;

        private string _user;
        private int _progress;

        public string User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public int Progress
        {
            get => _progress;
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                    OnPropertyChanged(nameof(Progress));
                }
            }
        }
 

        public UsersReportItem GetSource()
        {
            return _source;
        }

        public void SetSource(UsersReportItem source)
        {
            _source = source;
        }
    }
}