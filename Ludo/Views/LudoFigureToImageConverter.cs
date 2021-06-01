﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Ludo.Model;

namespace Ludo
{
    public class LudoFigureToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ELudoFigureColor figureColor = (ELudoFigureColor)value;
            switch (figureColor)
            {
                case ELudoFigureColor.Blue:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/blue.png",
                        UriKind.Absolute));
                case ELudoFigureColor.Red:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/red.png",
                        UriKind.Absolute));
                case ELudoFigureColor.Green:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/green.png",
                        UriKind.Absolute));
                case ELudoFigureColor.Yellow:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/yellow.png",
                        UriKind.Absolute));
                case ELudoFigureColor.Empty:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/empty.png",
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