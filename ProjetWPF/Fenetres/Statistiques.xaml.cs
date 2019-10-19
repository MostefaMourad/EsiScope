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


namespace ProjetWPF.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Statistiques.xaml
    /// </summary>
    public partial class Statistiques : UserControl
    {

        public List<ToggleSwitch> preference;
        public Statistiques()
        {
            InitializeComponent();
            preference = new List<ToggleSwitch> { ToggTempurature, ToggPression, ToggHumidite, ToggVent, ToggVisibilite, ToggPrecipitation, ToggNebulosite };
        }

        private void Togg_Click(object sender, RoutedEventArgs e)
        {
            int i = preference.IndexOf((ToggleSwitch)sender);
            algerie.preference[i] =(bool) ((ToggleSwitch)sender).IsChecked;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {            
            ZoomView.Height = 425+ ((Slider)sender).Value*10;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Height < 800) Row2.Width = new GridLength(0, GridUnitType.Star);
            else Row2.Width = new GridLength(71, GridUnitType.Star);
        }
    }
}
