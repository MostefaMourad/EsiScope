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
    /// <summary>
    /// Logique d'interaction pour Diagramme.xaml
    /// </summary>
    public partial class Doublecourbe : UserControl
    {      
        public Doublecourbe(List<Tuple<int, float>> Tableau1, List<Tuple<int, float>> Tableau2)
        {
            InitializeComponent();
            ChartValues<ObservablePoint> List1Points = new ChartValues<ObservablePoint>();
            ChartValues<ObservablePoint> List2Points = new ChartValues<ObservablePoint>();
            foreach (Tuple<int, float> Couple in Tableau1)
            {

                List1Points.Add(new ObservablePoint
                {
                    X = Couple.Item1,
                    Y = Couple.Item2
                });
            }
            foreach (Tuple<int, float> Couple in Tableau2)
            {

                List2Points.Add(new ObservablePoint
                {
                    X = Couple.Item1,
                    Y = Couple.Item2
                });
            }
            Chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = List1Points,
                    LineSmoothness=1,
                    PointGeometrySize=0,
                    StrokeThickness =0,

                },
                new LineSeries
                {
                    Values = List2Points,
                    LineSmoothness=1,
                    PointGeometrySize=0,
                    StrokeThickness =0,

                }
            };
        }
    }
}
