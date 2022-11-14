using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SnappetChallenge.Client.Helper;
using Xamarin.Forms;

namespace SnappetChallenge.Client.Control
{
    /// <summary>
    /// Tests if the ToString() of the bound value is equal to the value specified in the condition passed as the ConverterParameter, 
    ///     and return the true and false values specified in the ConverterParameter.
    /// 
    /// There can be muliple compare values can be specified for each return value, they are speparated by "?" character
    ///     (i.e., a?b?c:d would return c if a or b is a match, else d would be returned)
    /// Multiple return values can be specified by separatation by ":" character
    ///     (i.e., a?b:c?d:e would return b if a is a match, d if c is a match, otherwise would return e)
    /// These can be combined
    ///     (i.e., a?b?c:d?e would return c if a or b is a match, e if d is a match)
    public sealed class IsEqualConverter : IValueConverter
    {
        /// <summary>
        /// Binding must be equal to the specified value in the ConverterParameter string before the "?" to return
        ///     the value after the last "?". otherwise value after ":" is returned
        /// 
        /// SAMPLE:
        ///    Text="{Binding ElementName=TestComboBox,
        ///                   Path=Text,
        ///                   Converter={converterHelperSample:IsEqualConverter},
        ///                   ConverterParameter='a?a selected:b?c?b or c selected:other value selected'}" />
        /// 
        /// The true or false (or null) value is converted to the TargetType before being returned, an 
        ///     exception being thrown if the true or false string cannot be converted
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (value == null || parameter == null) return DependencyProperty.UnsetValue;
            return ConverterHelper.ResultWithParameterValue(
                p => string.Equals(value.ToString(), p, StringComparison.CurrentCultureIgnoreCase), targetType,
                parameter);
        }

        /// <summary>
        /// Not Implemented.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// All Bindings must be equal to the specified value in the ConverterParameter string before the "?" to return
        ///     the value after the last "?". else value after ":" is returned
        /// 
        /// SAMPLE:
        /// <TextBlock.Visibility>
		///		<MultiBinding Converter = "{converterHelperSample:IsEqualConverter}"
        ///                 ConverterParameter="a?Visible:Collapsed">
		///			<Binding ElementName = "ReasonTextBox"
        ///                     Path="Text" />
		///			<Binding ElementName = "TestComboBox"
        ///                     Path="Text" />
		///		</MultiBinding>
		///	</TextBlock.Visibility>
        /// </summary>
        /// <param name="values">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var parameterString = parameter.ToString();
            bool isTrue = false;
            if (parameterString.Contains("?"))
            {
                var compareValue = parameterString.Substring(0, parameterString.IndexOf("?", StringComparison.Ordinal));
                isTrue = values.All(i => i?.ToString() == compareValue);
            }
            else
            {
                isTrue = values.Skip(1).All(i => i?.ToString() == values[0]?.ToString());
            }
            return ConverterHelper.Result<bool?>(isTrue, i => i, targetType, parameter);
        }

        /// <summary>
        /// Not Implemented.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetTypes">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
