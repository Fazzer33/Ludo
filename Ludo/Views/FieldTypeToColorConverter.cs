using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Ludo.Model;

namespace Ludo
{
    public class FieldTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EPlayerColor color = (EPlayerColor)value;
            switch (color)
            {
                case EPlayerColor.Blue:
                    return new SolidColorBrush(Colors.Blue);
                case EPlayerColor.Red:
                    return new SolidColorBrush(Colors.Red);
                case EPlayerColor.Green:
                    return new SolidColorBrush(Colors.Green);
                case EPlayerColor.Yellow:
                    return new SolidColorBrush(Colors.Yellow);
                case EPlayerColor.Empty:
                    return new SolidColorBrush(Colors.AntiqueWhite);
                default:
                    throw new ArgumentException("Not supported field type.");
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}