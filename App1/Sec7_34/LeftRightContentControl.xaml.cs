﻿using System;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Sec7_34
{
    public sealed partial class LeftRightContentControl : UserControl
    {
        public LeftRightContentControl()
        {
            this.InitializeComponent();
        }

        public object LeftContent
        {
            get { return (object) GetValue(LeftContentProperty);}
            set { SetValue(LeftContentProperty, value); }
        }
        
        public static readonly DependencyProperty LeftContentProperty = 
            DependencyProperty.Register("LeftContent", typeof(object), 
                typeof(LeftRightContentControl), 
                new PropertyMetadata(null));
        public DataTemplate LeftTemplate
        {
            get { return (DataTemplate)GetValue(LeftTemplateProperty); }
            set { SetValue(LeftTemplateProperty, value); }
        }

        public static readonly DependencyProperty LeftTemplateProperty =
            DependencyProperty.Register("LeftTemplate", typeof(DataTemplate),
                typeof(LeftRightContentControl),
                new PropertyMetadata(null));

        public object RightContent
        {
            get { return (object)GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }
        }

        public static readonly DependencyProperty RightContentProperty =
            DependencyProperty.Register("RightContent", typeof(object),
                typeof(LeftRightContentControl),
                new PropertyMetadata(null));

        public DataTemplate RightTemplate
        {
            get { return (DataTemplate)GetValue(RightTemplateProperty); }
            set { SetValue(RightTemplateProperty, value); }
        }

        public static readonly DependencyProperty RightTemplateProperty =
            DependencyProperty.Register("RightTemplate", typeof(DataTemplate),
                typeof(LeftRightContentControl),
                new PropertyMetadata(null));
    }
}
