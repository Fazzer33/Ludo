using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Ludo
{
    public class FieldTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EFieldColor color = (EFieldColor)value;
            switch (color)
            {
                case EFieldColor.FieldBlue:
                    return new SolidColorBrush(Colors.Blue);
                case EFieldColor.FieldRed:
                    return new SolidColorBrush(Colors.Red);
                case EFieldColor.FieldGreen:
                    return new SolidColorBrush(Colors.Green);
                case EFieldColor.FieldYellow:
                    return new SolidColorBrush(Colors.Yellow);
                case EFieldColor.FieldBasic:
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