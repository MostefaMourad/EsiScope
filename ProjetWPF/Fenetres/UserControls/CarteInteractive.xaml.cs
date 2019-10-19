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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ProjetWPF.Fenetres.UserControls;

namespace ProjetWPF.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour CarteInteractive.xaml
    /// </summary>
    public partial class CarteInteractive : UserControl
    {

        public List<bool> preference;



        public CarteInteractive()
        {
            preference = new List<bool>
            {
                true,true,true, true,true,true,true
            };
            InitializeComponent();
        }
        private void Path_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int x = int.Parse((((Path)sender).Name).Remove(0,1));
            if (preference.IndexOf(true) < 0)
            {
                MessageBoxAlert.Show("Vous devez sélectionner au moins une préférence.", "");
            }
            else
            {
                Statistique stat = new Statistique(x, preference);
                stat.Show();
            }
        }
        private void Path_MouseEnter(object sender, MouseEventArgs e)
        {

            ((Path)sender).Fill = Brushes.DarkBlue;
        }

        private void Path_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Path)sender).Fill = new SolidColorBrush(Color.FromArgb(255, 244, 244, 244));
        }

        private void W37_MouseMove(object sender, MouseEventArgs e)
        {
            tt37.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt37.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt37.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W08_MouseMove(object sender, MouseEventArgs e)
        {
            tt08.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt08.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt08.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W01_MouseMove(object sender, MouseEventArgs e)
        {
            tt01.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt01.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt01.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W11_MouseMove(object sender, MouseEventArgs e)
        {
            tt11.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt11.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt11.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W33_MouseMove(object sender, MouseEventArgs e)
        {
            tt33.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt33.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt33.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W30_MouseMove(object sender, MouseEventArgs e)
        {
            tt30.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt30.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt30.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W47_MouseMove(object sender, MouseEventArgs e)
        {

            tt47.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt47.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt47.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W45_MouseMove(object sender, MouseEventArgs e)
        {
            tt45.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt45.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt45.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W32_MouseMove(object sender, MouseEventArgs e)
        {
            tt32.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt32.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt32.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W03_MouseMove(object sender, MouseEventArgs e)
        {
            tt03.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt03.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt03.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W13_MouseMove(object sender, MouseEventArgs e)
        {
            tt13.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt13.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt13.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W20_MouseMove(object sender, MouseEventArgs e)
        {
            tt20.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt20.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt20.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W46_MouseMove(object sender, MouseEventArgs e)
        {
            tt46.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt46.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt46.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W31_MouseMove(object sender, MouseEventArgs e)
        {
            tt31.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt31.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt31.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W29_MouseMove(object sender, MouseEventArgs e)
        {
            tt29.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt29.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt29.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W27_MouseMove(object sender, MouseEventArgs e)
        {
            tt27.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt27.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt27.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W48_MouseMove(object sender, MouseEventArgs e)
        {
            tt48.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt48.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt48.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W02_MouseMove(object sender, MouseEventArgs e)
        {
            tt02.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt02.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt02.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W14_MouseMove(object sender, MouseEventArgs e)
        {
            tt14.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt14.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt14.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W17_MouseMove(object sender, MouseEventArgs e)
        {
            tt17.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt17.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt17.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W38_MouseMove(object sender, MouseEventArgs e)
        {
            tt38.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt38.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt38.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W44_MouseMove(object sender, MouseEventArgs e)
        {
            tt44.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt44.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt44.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W42_MouseMove(object sender, MouseEventArgs e)
        {
            tt42.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt42.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt42.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W26_MouseMove(object sender, MouseEventArgs e)
        {
            tt26.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt26.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt26.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W09_MouseMove(object sender, MouseEventArgs e)
        {
            tt09.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt09.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt09.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W16_MouseMove(object sender, MouseEventArgs e)
        {
            tt16.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt16.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt16.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W39_MouseMove(object sender, MouseEventArgs e)
        {
            tt39.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt39.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt39.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W12_MouseMove(object sender, MouseEventArgs e)
        {
            tt12.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt12.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt12.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W40_MouseMove(object sender, MouseEventArgs e)
        {
            tt40.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt40.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt40.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W05_MouseMove(object sender, MouseEventArgs e)
        {
            tt05.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt05.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt05.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W04_MouseMove(object sender, MouseEventArgs e)
        {
            tt04.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt04.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt04.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W41_MouseMove(object sender, MouseEventArgs e)
        {
            tt41.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt41.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt41.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W36_MouseMove(object sender, MouseEventArgs e)
        {
            tt36.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt36.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt36.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W07_MouseMove(object sender, MouseEventArgs e)
        {
            tt07.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt07.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt07.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W28_MouseMove(object sender, MouseEventArgs e)
        {
            tt28.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt28.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt28.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W10_MouseMove(object sender, MouseEventArgs e)
        {
            tt10.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt10.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt10.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W35_MouseMove(object sender, MouseEventArgs e)
        {
            tt35.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt35.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt35.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W15_MouseMove(object sender, MouseEventArgs e)
        {
            tt15.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt15.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt15.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W23_MouseMove(object sender, MouseEventArgs e)
        {
            tt23.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt23.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt23.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W24_MouseMove(object sender, MouseEventArgs e)
        {
            tt24.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt24.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt24.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W21_MouseMove(object sender, MouseEventArgs e)
        {
            tt21.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt21.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt21.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W25_MouseMove(object sender, MouseEventArgs e)
        {
            tt25.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt25.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt25.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W18_MouseMove(object sender, MouseEventArgs e)
        {
            tt18.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt18.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt18.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W43_MouseMove(object sender, MouseEventArgs e)
        {
            tt43.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt43.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt43.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W19_MouseMove(object sender, MouseEventArgs e)
        {
            tt19.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt19.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt19.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W06_MouseMove(object sender, MouseEventArgs e)
        {
            tt06.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt06.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt06.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W34_MouseMove(object sender, MouseEventArgs e)
        {
            tt34.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt34.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt34.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }

        private void W22_MouseMove(object sender, MouseEventArgs e)
        {
            tt42.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt42.HorizontalOffset = e.GetPosition((IInputElement)sender).X - 70;
            tt42.VerticalOffset = e.GetPosition((IInputElement)sender).Y - 40;
        }
    }
}
