using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Ludo.Model;

namespace Ludo
{
    public class PlayerColorToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EPlayerColor playerColor = (EPlayerColor)value;
            switch (playerColor)
            {
                case EPlayerColor.Blue:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/blue.png",
                        UriKind.Absolute));
                case EPlayerColor.Red:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/red.png",
                        UriKind.Absolute));
                case EPlayerColor.Green:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/green.png",
                        UriKind.Absolute));
                case EPlayerColor.Yellow:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/yellow.png",
                        UriKind.Absolute));
                default:
                    throw new ArgumentException("Not supported figure type.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}