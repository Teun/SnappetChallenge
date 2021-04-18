using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.Properties;
using Windows.Services;
using BlCore.ReportServices.Models;

namespace Windows.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly SnappetApiService _snappetApiService;

        private ObservableCollection<object> _items;
        private DateTime _beginDt;
        private DateTime _endDt;
        private object _selectedItem;
        private string _total;

        public ICommand ShowSelectedCommand { get; }

        public ICommand ShowObjectivesCommand { get; }

        public ICommand ShowUsersCommand { get; }

        public ICommand TodayCommand { get; }

        public ICommand WeekCommand { get; }

        public ICommand MonthCommand { get; }

        public ObservableCollection<object> Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        public DateTime BeginDt
        {
            get => _beginDt;
            set
            {
                if (_beginDt != value)
                {
                    _beginDt = value;
                    OnPropertyChanged(nameof(BeginDt));
                }
            }
        }

        public DateTime EndDt
        {
            get => _endDt;
            set
            {
                if (_endDt != value)
                {
                    _endDt = value;
                    OnPropertyChanged(nameof(EndDt));
                }
            }
        }

        public object SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public string Total
        {
            get => _total;
            set
            {
                if (_total != value)
                {
                    _total = value;
                    OnPropertyChanged(nameof(Total));
                }
            }
        }

        public MainWindowViewModel()
        {
            _snappetApiService = new SnappetApiService();
            _items = new ObservableCollection<object>();
            ShowObjectivesCommand = new ActionCommand(ShowObjectives);
            ShowUsersCommand = new ActionCommand(ShowUsers);
            ShowSelectedCommand = new ActionCommand(ShowSelected);
            TodayCommand = new ActionCommand(Today);
            WeekCommand = new ActionCommand(Week);
            MonthCommand = new ActionCommand(Month);
            Today();
        }

        private void Today()
        {
            DateTime today = GetToday();
            BeginDt = today;
            EndDt = today.AddDays(1).AddTicks(-1);
        }

        private void Week()
        {
            DateTime today = GetToday();
            EndDt = today;
            DayOfWeek dayOfWeek = today.DayOfWeek;
            while (dayOfWeek != DayOfWeek.Monday)
            {
                today = today.AddDays(-1);
                dayOfWeek = today.DayOfWeek;
            }
            BeginDt = today;
        }
        private void Month()
        {
            DateTime today = GetToday();
            EndDt = today;
            BeginDt = new DateTime(today.Year, today.Month, 1, 0, 0, 0);
        }

        private DateTime GetToday()
        {
            return new DateTime(2015, 03, 30, 0, 0, 0);
        }

        private void ShowObjectives()
        {
            try
            {
                var report = _snappetApiService.GetObjectiveReport(BeginDt, EndDt);
                var viewModelItems = new List<ObjectivesReportItemViewModel>();
                foreach (var item in report.Items)
                {
                    var vmItem = new ObjectivesReportItemViewModel
                    {
                        Domain = item.Domain,
                        Subject = item.Subject,
                        Objective = item.Objective,
                        Count = item.Count
                    };
                    vmItem.SetSource(item);
                    viewModelItems.Add(vmItem);
                }
                Items = new ObservableCollection<object>(viewModelItems);
                Total = string.Format(Resources.CountTemplate, report.Total.ObjectiveCount);
            }
            catch (Exception e)
            {
                Total = e.Message;
            }
        }

        private void ShowUsers()
        {
            try
            {
                var report = _snappetApiService.GetUsersReport(BeginDt, EndDt);
                var viewModelItems = new List<UsersReportItemViewModel>();
                foreach (UsersReportItem item in report.Items)
                {
                    var vmItem = new UsersReportItemViewModel
                    {
                        Progress = item.Progress,
                        User = string.Format(Resources.UserTemplate, item.User)
                    };
                    vmItem.SetSource(item);
                    viewModelItems.Add(vmItem);
                }
                Items = new ObservableCollection<object>(viewModelItems);
                Total = string.Format(Resources.UsersTotalTemplate, report.Total.UsersCount, report.Total.Progress, report.Total.AverageProgress);
            }
            catch (Exception e)
            {
                Total = e.Message;
            }
        }

        private void ShowSelected()
        {
            try
            {
                if (SelectedItem is ObjectivesReportItemViewModel so)
                {
                    var report = _snappetApiService.GetOneObjectiveReport(so.GetSource().Objective, BeginDt, EndDt);
                    var viewModelItems = new List<OneObjectiveReportItemViewModel>();
                    foreach (OneObjectiveReportItem item in report.Items)
                    {
                        var vmItem = new OneObjectiveReportItemViewModel
                        {
                            User = $"User {item.User}",
                            Progress = item.Progress
                        };
                        vmItem.SetSource(item);
                        viewModelItems.Add(vmItem);
                    }
                    Items = new ObservableCollection<object>(viewModelItems);
                    Total = string.Format(Resources.OneObjectiveTotalTemplate, report.Total.Objective, report.Total.UsersCount, report.Total.Progress, report.Total.AverageProgress);
                }

                int userId = 0;
                bool isUser = false;
                if (SelectedItem is UsersReportItemViewModel su)
                {
                    isUser = true;
                    userId = su.GetSource().User;
                }
                else if (SelectedItem is OneObjectiveReportItemViewModel oo)
                {
                    isUser = true;
                    userId = oo.GetSource().User;
                }
                if (isUser)
                {
                    var report = _snappetApiService.GetOneUserReport(userId.ToString(), BeginDt, EndDt);
                    var viewModelItems = new List<OneUserReportItemViewModel>();
                    foreach (OneUserReportItem item in report.Items)
                    {
                        var vmItem = new OneUserReportItemViewModel
                        {
                            ActionDt = item.ActionDt,
                            Correct = item.Correct,
                            Difficulty = item.Difficulty,
                            User = $"User {item.User}",
                            Exercise = $"Exercise {item.Exercise}",
                            Progress = item.Progress,
                            Objective = item.Objective,
                            Subject = item.Subject,
                            Domain = item.Domain
                        };
                        vmItem.SetSource(item);
                        viewModelItems.Add(vmItem);
                    }
                    Items = new ObservableCollection<object>(viewModelItems);
                    Total = string.Format(Resources.OneUserTotalTemplate, report.Total.User, report.Total.ItemsCount, report.Total.Progress, report.Total.AverageProgress);
                }
            }
            catch (Exception e)
            {
                Total = e.Message;
            }
        }
    }
}
