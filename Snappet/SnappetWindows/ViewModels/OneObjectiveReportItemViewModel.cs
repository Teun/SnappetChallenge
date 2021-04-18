using BlCore.ReportServices.Models;

namespace Windows.ViewModels
{
    public class OneObjectiveReportItemViewModel : ViewModelBase
    {
        private OneObjectiveReportItem _source;
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

        public OneObjectiveReportItem GetSource()
        {
            return _source;
        }

        public void SetSource(OneObjectiveReportItem source)
        {
            _source = source;
        }
    }
}