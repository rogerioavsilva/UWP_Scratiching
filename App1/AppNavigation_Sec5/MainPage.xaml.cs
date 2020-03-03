﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppNavigation_Sec5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if(InnerFrame.BackStack.Any())
            {
                e.Handled = true;
                InnerFrame.GoBack();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            InnerFrame.Navigate(typeof(BlankSubPage1));
            this.GoBackButton.IsEnabled = InnerFrame.BackStack.Any();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InnerFrame.Navigate(typeof(BlankSubPage1));
            this.GoBackButton.IsEnabled = InnerFrame.BackStack.Any();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = InnerFrame.BackStack.Any() ? 
                AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InnerFrame.Navigate(typeof(BlankSubPage2));
            this.GoBackButton.IsEnabled = InnerFrame.BackStack.Any();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = InnerFrame.BackStack.Any() ? 
                AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            InnerFrame.GoBack();
            this.GoBackButton.IsEnabled = InnerFrame.BackStack.Any();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = InnerFrame.BackStack.Any() ? 
                AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }
    }
}
