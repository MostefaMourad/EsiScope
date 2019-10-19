using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;

namespace ProjetWPF.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Diagramme.xaml
    /// </summary>
    public partial class Diagramme : UserControl
    {
        public Diagramme(List<Tuple<int, float>> Tableau)
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
            TemperatureChart.Series = new SeriesCollection
            {
                new LiveCharts.Wpf.ColumnSeries
                {
                    Values = List1Points,
                },
            };
        }
    }
}
