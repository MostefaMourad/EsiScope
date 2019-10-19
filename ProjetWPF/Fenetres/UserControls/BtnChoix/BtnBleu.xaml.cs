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

namespace ProjetWPF.Fenetres.UserControls.BtnChoix
{
    /// <summary>
    /// Logique d'interaction pour BtnBleu.xaml
    /// </summary>
    public partial class BtnBleu : UserControl
    {
        public BtnBleu(string AMJ, string Date)
        {
            InitializeComponent();
            Title.Text = AMJ;
            DateAff.Text = Date;
            Lettre.Text = AMJ.Remove(1);
        }
        private void Bouton3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
  
        }
    }
}
