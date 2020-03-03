using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppNavigation_Dialogs_sec5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {



            //var menu = new PopupMenu();
            //menu.Commands.Add(new UICommand("5 stars", null, 5));
            //menu.Commands.Add(new UICommand("4 stars", null, 5));
            //menu.Commands.Add(new UICommand("3 stars", null, 5));
            //menu.Commands.Add(new UICommand("2 stars", null, 5));
            //menu.Commands.Add(new UICommand("1 stars", null, 5));

            //var buttton = sender as Button;
            //var point = buttton.TransformToVisual(null).TransformPoint(new Point());
            //var result = await menu.ShowAsync(point);
            //Result.Text = result?.Label ?? "Nothing";

            //var dialog = new ContentDialog()
            //{
            //    Title = "Delete item",
            //    Content = "Are you sure you want to delete this item?",
            //    PrimaryButtonText = "Yes",
            //    SecondaryButtonText = "No"
            //};

            //var result = await dialog.ShowAsync();
            //Result.Text = result.ToString();
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Result.Text = (sender as FrameworkElement).Tag as string;
            ((((sender as FrameworkElement).Parent as FrameworkElement).Parent as FlyoutPresenter).Parent as Popup).IsOpen = false;

        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
        }
    }
}
