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
using ProjetWPF.Fenetres.UserControls.BtnChoix;

namespace ProjetWPF.Fenetres.UserControls
{
    /// <summary>
    /// Logique d'interaction pour Statistique.xaml
    /// </summary>
    public partial class Statistique : MetroWindow
    {
        

        public Statistique(int Wilaya,List<bool> preference)
        {
            InitializeComponent();
            this.Title = ((WilayaAlgerie)(Wilaya-1)).ToString();
            InitializeTabControl(Wilaya,preference);
        }
        public void InitializeTabControl(int wilaya,List<bool> preference)
        {
            if (preference[0]) TempStatAnne(wilaya);
            if (preference[1]) PressStatAnne(wilaya);
            if (preference[2]) HumiStatAnne(wilaya);
            if (preference[3]) VentStatAnne(wilaya);
            if (preference[4]) VisibStatAnne(wilaya);
            if (preference[5]) PreciStatAnne(wilaya);
            if (preference[6]) NebuStatAnne( wilaya);
        } 
        public void TempStatAnne(int wilaya)
        {
            TabItem t1 = new TabItem();
            ControlStat controlStat = new ControlStat(wilaya, 1, "Temperature","°");
            t1.Content = controlStat;
            WrapPanel wrapPanel = new WrapPanel{Height = 30};
            wrapPanel.Children.Add(new Image{Source = new BitmapImage(new Uri(@"..\..\Rousources\Icons\Thermometer-75.png", UriKind.Relative)),Height =30, Width = 30, Margin = new Thickness(-5,0, 0, 0) });
            wrapPanel.Children.Add(new Label { Content = "Temperature",Margin = new Thickness(-10, 0, 0, 0)});
            t1.Header = wrapPanel;
            tabStat.Items.Add(t1);
        }
        public void PressStatAnne(int wilaya)
        {
            TabItem t1 = new TabItem();
            ControlStat controlStat = new ControlStat(wilaya,4, "Pression","Pa");          
            t1.Content = controlStat;
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Children.Add(new Image{Source = new BitmapImage(new Uri(@"..\..\Rousources\Icons\air.png", UriKind.Relative)),Height = 25,Width=25});
            wrapPanel.Children.Add(new Label {Content = "Pression"});
            t1.Header = wrapPanel;
            tabStat.Items.Add(t1);           
        }
        public void HumiStatAnne(int wilaya)
        {
            TabItem t1 = new TabItem();
            ControlStat controlStat = new ControlStat(wilaya,3, "Humidité","%");
            t1.Content = controlStat;
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Children.Add( new Image{ Source = new BitmapImage(new Uri(@"..\..\Rousources\Icons\humidity.png", UriKind.Relative)),  Height = 13,Width=13 });
            wrapPanel.Children.Add( new Label  {   Content = "Humidité"  } );
            t1.Header = wrapPanel;
            tabStat.Items.Add(t1);
        }
        public void VentStatAnne(int wilaya)
        {
            TabItem t1 = new TabItem();
            ControlStat controlStat = new ControlStat(wilaya, 7, "Vent","m/s");
            t1.Content = controlStat;
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Children.Add( new Image{Source = new BitmapImage(new Uri(@"..\..\Rousources\Icons\anemometer.png", UriKind.Relative)),Height = 20,Width = 20});
            wrapPanel.Children.Add(new Label{Content = "Vent"});
            t1.Header = wrapPanel;
            tabStat.Items.Add(t1);
        }
        public void VisibStatAnne(int wilaya)
        {
            TabItem t1 = new TabItem();
            ControlStat controlStat = new ControlStat(wilaya, 6, "Visibilité","Km");
            t1.Content = controlStat;
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Children.Add(new Image{Source = new BitmapImage(new Uri(@"..\..\Rousources\Icons\eye.png", UriKind.Relative)),Height = 13,Width=13});
            wrapPanel.Children.Add(new Label {Content = "Visibilité"});
            t1.Header = wrapPanel;
            tabStat.Items.Add(t1);
        }
        public void PreciStatAnne(int wilaya)
        {
            TabItem t1 = new TabItem();
            ControlStat controlStat = new ControlStat(wilaya, 5, "Précipitation","mm");
            t1.Content = controlStat;
            WrapPanel wrapPanel = new WrapPanel();wrapPanel.Children.Add(new Image{Source = new BitmapImage(new Uri(@"..\..\Rousources\Icons\precipitation.png", UriKind.Relative)),Height = 10});
            wrapPanel.Children.Add(new Label{Content = "Précipitation"});
            t1.Header = wrapPanel;
            tabStat.Items.Add(t1);
        }
        public void NebuStatAnne(int wilaya)
        {
            TabItem t1 = new TabItem();
            ControlStat controlStat = new ControlStat(wilaya, 8, "Nébulosité","%");
            t1.Content = controlStat;
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Children.Add(new Image{Source = new BitmapImage(new Uri(@"..\..\Rousources\Icons\winter.png", UriKind.Relative)),Height = 25,Width=25});
            wrapPanel.Children.Add(new Label{Content = "Nébulosité"});
            t1.Header = wrapPanel;
            tabStat.Items.Add(t1);
        }
    }
}
