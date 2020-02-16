using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App7
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Browser.Navigate(new Uri("http://www.pearson.com"));
            // Browser.Navigate(new Uri("ms-appx-web://help.html"));
            //Browser.NavigateToString("<center>My html</center>");

            var point = new Geopoint(new BasicGeoposition() 
            { 
                Latitude = 45.4215,
                Longitude = -75.6972
            });

            Map.Center = point;

            MapControl.SetLocation(TickMark, point);
            MapControl.SetNormalizedAnchorPoint(TickMark, new Windows.Foundation.Point(0.5, 0.5));

        }
    }
}
