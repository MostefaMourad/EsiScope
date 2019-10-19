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

namespace ProjetWPF.Fenetres.UserControls
{
    /// <summary>
    /// Logique d'interaction pour boussole.xaml
    /// </summary>
    public partial class boussole : UserControl
    {
        public boussole()
        {
            InitializeComponent();

        }
        public void SetValue(float vitesse, Direction direction)
        {
            Vitesse.Content = (int)vitesse;
            Angle.Angle = 45;
            if (direction == Direction.NON)
                RedLine.Visibility = Visibility.Hidden;
            else
                Angle.Angle = 45 * ((int)direction - 1);
        }
    }
}
