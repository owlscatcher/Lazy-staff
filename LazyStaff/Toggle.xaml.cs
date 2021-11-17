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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LazyStaff
{
    /// <summary>
    /// Логика взаимодействия для Toggle.xaml
    /// </summary>
    public partial class Toggle : UserControl
    {
        // Marge параметр Dot для положений Left и Ride
        Thickness LeftSide = new Thickness(-345, 0, 0, 0);
        Thickness RideSide = new Thickness(345, 0, 0, 0);

        // Fill параметр Back для положений Off и On
        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(160, 160, 160));                // в HEX #FFA0A0A0 - серый
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(149, 221, 128));                 // в HEX #95DD80 - пастельно-зеленый

        public Toggle()
        {
            InitializeComponent();
        }

        public bool Toggled { get; set; } = false;

        private void Dot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Если Toggle не true  
            if(!Toggled)
            {
                Back.Fill = On;
                Dot.Margin = RideSide;
                Toggled = true;
            }
            else
            {
                Back.Fill = Off;
                Dot.Margin = LeftSide;
                Toggled = false;
            }
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Если Toggle не true  
            if (!Toggled)
            {
                Back.Fill = On;
                Dot.Margin = RideSide;
                Toggled = true;
            }
            else
            {
                Back.Fill = Off;
                Dot.Margin = LeftSide;
                Toggled = false;
            }
        }
    }
}
