using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Sec6_Leason28
{
    public class StyleToBrushConverter : IValueConverter
    {
        public SolidColorBrush _default = new SolidColorBrush(Windows.UI.Colors.White);
        public SolidColorBrush _Mexican = new SolidColorBrush(Windows.UI.Colors.LightPink);
        public SolidColorBrush _Desserts = new SolidColorBrush(Windows.UI.Colors.Chocolate);


        public StyleToBrushConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value as string)
            {
                case null:
                default:
                    return _default;
                case "Mexican":
                    return _Mexican;
                case "Desserts":
                    return _Desserts;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
