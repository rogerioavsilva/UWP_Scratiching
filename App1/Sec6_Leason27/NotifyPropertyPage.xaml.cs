using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sec6_Leason27
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NotifyPropertyPage : Page
    {
        public NotifyPropertyPage()
        {
            this.InitializeComponent();

            var infos = new TruckInfo[]
            {
                new TruckInfo() { ID = "1", Name = "Taco Talent", Style = "Mexican" },
                new TruckInfo() { ID = "2", Name = "Cake Shack", Style = "Desserts" },
                new TruckInfo() { ID = "3", Name = "Ice Heaven", Style = "Cold Drinks" },
            };

            var data = new TruckDataNotify()
            {
                Trucks = new ObservableCollection<TruckInfo>(infos)
            };

            DataContext = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as TruckDataNotify).Trucks.Add(
                new TruckInfo() { ID = "4", Name = "Fancy Fish", Style = "Fish" }
                );
        }
    }

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

    public class TruckDataNotify : NotificationBase
    {
        public ObservableCollection<TruckInfo> Trucks { get; set; }
        private TruckInfo _SelectedTruck;

        public event PropertyChangedEventHandler PropertyChanged;

        public TruckInfo SelectedTruck
        {
            get { return _SelectedTruck;  }
            set 
            {
                if (_SelectedTruck == value)
                    return;

                 _SelectedTruck = value;

                NotifyPropertyChange();
            
            }
        }
    }

    public class NotificationBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChange([CallerMemberName] string name = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
