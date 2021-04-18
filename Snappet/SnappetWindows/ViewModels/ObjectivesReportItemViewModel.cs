using BlCore.ReportServices.Models;

namespace Windows.ViewModels
{
    public class ObjectivesReportItemViewModel : ViewModelBase
    {
        private ObjectivesReportItem _source;

        private string _domain;
        private string _subject;
        private string _objective;
        private int _count;

        public string Domain
        {
            get => _domain;
            set
            {
                if (_domain != value)
                {
                    _domain = value;
                    OnPropertyChanged(nameof(Domain));
                }
            }
        }

        public string Subject
        {
            get => _subject;
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    OnPropertyChanged(nameof(Subject));
                }
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Count));
                }
            }
        }

        public string Objective
        {
            get => _objective;
            set
            {
                if (_objective != value)
                {
                    _objective = value;
                    OnPropertyChanged(nameof(Objective));
                }
            }
        }
        
        public ObjectivesReportItem GetSource()
        {
            return _source;
        }

        public void SetSource(ObjectivesReportItem source)
        {
            _source = source;
        }
    }
}
