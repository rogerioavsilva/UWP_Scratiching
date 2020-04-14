using System;
using System.Collections.Generic;
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

namespace Sec8_43
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SView.IsPaneOpen = !SView.IsPaneOpen;
        }
    }

    public class WindowWithAdaptiveTrigger : StateTriggerBase
    {
        public WindowWithAdaptiveTrigger()
        {
            var coreWindow = Windows.UI.Core.CoreWindow.GetForCurrentThread();
            if (coreWindow == null)
                return;

            coreWindow.SizeChanged += (s, e) => AssessTrigger(e.Size);
        }

        private double _minWindowWidth;

        public double MinWindowWidth
        {
            get { return _minWindowWidth; }
            set 
            {
                if (_minWindowWidth == value)
                    return;

                _minWindowWidth = value;

                var coreWindow = Windows.UI.Core.CoreWindow.GetForCurrentThread();
                if (coreWindow == null)
                    return;

                var bounds = coreWindow.Bounds;
                AssessTrigger(new Size(bounds.Right - bounds.Left, bounds.Bottom - bounds.Top));

            }
        }

        bool _isActive = false;

        private void AssessTrigger(Size size)
        {
            var IsActive = size.Width >= MinWindowWidth;
            if(_isActive != IsActive)
            {
                _isActive = IsActive;
                base.SetActive(IsActive);
            }
        }
    }
}
