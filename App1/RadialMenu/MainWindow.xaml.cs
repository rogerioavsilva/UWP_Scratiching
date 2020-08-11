using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RadialMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GMenu_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch {}
        }

        private void BtnEExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private Storyboard storyboard;
        public ColorAnimation SetButtonColorAnimation(Color color, string objName)
        {
            ColorAnimation colorAnimation = new ColorAnimation();
            colorAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            colorAnimation.To = color;
            Storyboard.SetTargetName(colorAnimation, objName);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Button.Background).(SolidColorBrush.Color)"));
            return colorAnimation;
        }

        public ColorAnimation SetCircleColorAnimation(Color color)
        {
            ColorAnimation colorAnimation = new ColorAnimation();
            colorAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            colorAnimation.To = color;
            Storyboard.SetTargetName(colorAnimation, "ColorCircle");
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath(GradientStop.ColorProperty));
            return colorAnimation;
        }

        private void Btn_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = (Button) sender;
            Color background = ((SolidColorBrush) btn.BorderBrush).Color;
            storyboard = new Storyboard();
            storyboard.Children.Add(SetButtonColorAnimation(background, btn.Name));
            storyboard.Children.Add(SetCircleColorAnimation(background));
            storyboard.Begin(this);
        }

        private void Btn_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            Color background = ((SolidColorBrush)btn.BorderBrush).Color;
            storyboard = new Storyboard();
            storyboard.Children.Add(SetButtonColorAnimation(Color.FromRgb(113,110,110), btn.Name));
            storyboard.Children.Add(SetCircleColorAnimation(Color.FromArgb(150,67,67,67)));
            storyboard.Begin(this);
        }
    }
}
