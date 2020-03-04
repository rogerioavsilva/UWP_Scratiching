using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sec6_Leason28
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public TruckData Data { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            var infos = new TruckInfo[]
            {
                new TruckInfo() { ID = "1", Name = "Taco Talent", Style = "Mexican" },
                new TruckInfo() { ID = "2", Name = "Cake Shack", Style = "Desserts" },
                new TruckInfo() { ID = "3", Name = "Ice Heaven", Style = "Cold Drinks" },
            };

            var data = new TruckData()
            {
                Trucks = new ObservableCollection<TruckInfo>(infos)
            };

            //    DataContext = data;

            Data = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
