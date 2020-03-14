using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Sec7_30
{
    public sealed partial class Rating : UserControl
    {
        public Rating()
        {
            this.InitializeComponent();
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(Rating), new PropertyMetadata(1));
    }

    public class GreaterOrEqualToIntToVisibilityConverter : IValueConverter
    {
        public int CompareValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((int)value >= CompareValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
