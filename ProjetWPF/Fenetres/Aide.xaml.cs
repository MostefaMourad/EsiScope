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

namespace ProjetWPF.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Aide.xaml
    /// </summary>
    public partial class Aide : UserControl
    {
        public Aide()
        {
            InitializeComponent();
        }

        private void Path_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Path)sender).Fill = new SolidColorBrush(Color.FromArgb(255, (byte)21, (byte)14, (byte)20)); 

        }

        private void Path_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Path)sender).Fill = new SolidColorBrush(Color.FromArgb(255, (byte)21, (byte)146, (byte)230));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(w1.Opacity== 0.5)
            {
                ok.Content = "1";
            }
            else if (w2.Opacity == 0.5)
            {
                ok.Content = "2";
            }
            else if (w3.Opacity == 0.5)
            {
                ok.Content = "3";
            }
        }

        private void W1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ok.Content = ((Path)sender).Name;
        }

        private void W1_MouseMove(object sender, MouseEventArgs e)
        {
        }
    }
}
