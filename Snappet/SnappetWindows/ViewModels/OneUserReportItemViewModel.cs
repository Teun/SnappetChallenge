using System;
using BlCore.ReportServices.Models;

namespace Windows.ViewModels
{
    public class OneUserReportItemViewModel : ViewModelBase
    {
        private OneUserReportItem _source;
        private string _user;
        private int _progress;

        private DateTime _actionDt;
        private string _domain;
        private string _correct;
        private string _exercise;
        private string _difficulty;
        private string _subject;
        private string _objective;

        public DateTime ActionDt
        {
            get => _actionDt;
            set
            {
                if (_actionDt != value)
                {
                    _actionDt = value;
                    OnPropertyChanged(nameof(ActionDt));
                }
            }
        }

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

        public string Correct
        {
            get => _correct;
            set
            {
                if (_correct != value)
                {
                    _correct = value;
                    OnPropertyChanged(nameof(Correct));
                }
            }
        }

        public string Exercise
        {
            get => _exercise;
            set
            {
                if (_exercise != value)
                {
                    _exercise = value;
                    OnPropertyChanged(nameof(Exercise));
                }
            }
        }


        public string Difficulty
        {
            get => _difficulty;
            set
            {
                if (_difficulty != value)
                {
                    _difficulty = value;
                    OnPropertyChanged(nameof(Difficulty));
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

        public OneUserReportItem GetSource()
        {
            return _source;
        }

        public void SetSource(OneUserReportItem source)
        {
            _source = source;
        }
    }
}