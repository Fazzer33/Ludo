using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Ludo
{
    public class NumberToDiceImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = (int) value;
            switch (number)
            {
             
                case 1:
                    Console.WriteLine("Within Converter");
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Dices/One.png",
                        UriKind.Absolute));
                case 2:
                    Console.WriteLine("Within Converter");
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Dices/Two.png",
                        UriKind.Absolute));
                case 3:
                    Console.WriteLine("Within Converter");
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Dices/Three.png",
                        UriKind.Absolute));
                case 4:
                    Console.WriteLine("Within Converter");
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Dices/Four.png",
                        UriKind.Absolute));
                case 5:
                    Console.WriteLine("Within Converter");
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Dices/Five.png",
                        UriKind.Absolute));
                case 6:
                    Console.WriteLine("Within Converter");
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Dices/Six.png",
                        UriKind.Absolute));
                default:
                    throw new ArgumentException("Not supported dice number.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}