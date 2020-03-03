using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Navigation_MultWin_Sec5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int _MainViewId;
        Dictionary<int, CoreApplicationView> _IDToView = new Dictionary<int, CoreApplicationView>();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            _MainViewId = ApplicationView.GetForCurrentView().Id;
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => 
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(SecondaryWindowPage), _MainViewId);
                Window.Current.Content = frame;
                Window.Current.Activate();
                Window.Current.Closed += Current_Closed;


                newViewId = ApplicationView.GetForCurrentView().Id;
            });

            _IDToView.Add(newViewId, newView);

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }

        private void Current_Closed(object sender, CoreWindowEventArgs e)
        {
            var id = ApplicationView.GetForCurrentView().Id;
            _IDToView.Remove(id);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var view in _IDToView.Values)
            {
                await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Window.Current.Close();
                });
            }

            _IDToView.Clear();
        }
    }
}
