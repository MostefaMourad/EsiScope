using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace ProjetWPF.Fenetres.UserControls
{
    /// <summary>
    /// Logique d'interaction pour Pass.xaml
    /// </summary>
    public partial class Pass : MetroWindow

    {
        public Pass()
        {
            InitializeComponent();
        }
        private void Button_Click_D(object sender, RoutedEventArgs e)
        {
            if (IOData.Autintification(PassWd.Password))
            {
                DialogResult = true;
                this.Close();
            }
            else
            {
                MpFaux.Visibility = Visibility.Visible;
            }

        }
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
