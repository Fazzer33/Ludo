using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Ludo.Model;

namespace Ludo
{
    public class PawnToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PawnId pawn = (PawnId)value;
            if (pawn != null)
            {
                switch (pawn.Color)
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
                    case EPlayerColor.Empty:
                        return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/empty.png",
                            UriKind.Absolute));
                    default:
                        throw new ArgumentException("Not supported figure type.");
                }
            }

            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}