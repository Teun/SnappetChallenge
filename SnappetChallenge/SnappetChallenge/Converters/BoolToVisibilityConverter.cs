using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SnappetChallenge.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                // If a bool parameter is used, it is treated as 'VisibileWhenTrue'
                // i.e. if it's true, the control is Visible when booleanValue is true, otherwise the inverse
                if (parameter is bool boolParameter)
                {
                    return boolParameter ? (booleanValue ? Visibility.Visible : Visibility.Collapsed)
                        : (booleanValue ? Visibility.Collapsed : Visibility.Visible);
                }

                // If no bool parameter then controls are hidden when booleanValue is true, visible when false
                return booleanValue ? Visibility.Collapsed : Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is Visibility visibility) && visibility == Visibility.Visible;
        }
    }
}