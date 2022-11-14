using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SnappetChallenge.Client.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isDevelopmetEnvironment;


        public bool IsDevelopmetEnvironment
        {
            get => _isDevelopmetEnvironment;
            set
            {
                _isDevelopmetEnvironment = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
                if (IsDevelopmetEnvironment)
                    SnappentSetting.snappentSetting.CurrentEnvironment = Constants.DevelopmetEnvironmentBaseUrl;
                else
                    SnappentSetting.snappentSetting.CurrentEnvironment = Constants.ProductionEnvironmentBaseUrl;
            }
        }

        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}