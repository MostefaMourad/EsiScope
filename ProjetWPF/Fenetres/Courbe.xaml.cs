using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace ProjetWPF.Fenetres
{
    public partial class Courbe : UserControl
    {
          
        public Courbe(List<Tuple<int, float>> Tableau)
        {
            InitializeComponent();
            ChartValues<ObservablePoint> List1Points = new ChartValues<ObservablePoint>();
            foreach (Tuple<int, float> Couple in Tableau)
            {

                List1Points.Add(new ObservablePoint
                {
                    X = Couple.Item1,
                    Y = Couple.Item2
                });
            }
            Chart.Series = new SeriesCollection
            {
                new LiveCharts.Wpf.LineSeries
                {
                    Values = List1Points,
                },
            };
        }
    }
}
