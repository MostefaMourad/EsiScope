using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjetWPF.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Recuperartion.xaml
    /// </summary>
    public partial class Recuperartion :MetroWindow
    {
        public bool deja=false;
        public Recuperartion()
        {
            InitializeComponent();
        }



        private void NumericUpDown_MouseEnter(object sender, MouseEventArgs e)
        {
            NumericUpDown Variable = (NumericUpDown)sender;
            TextBlock MyLabel= TmpMaxLabel;
            switch (Variable.Name)
            {
                case "TmpMax":
                    MyLabel = TmpMaxLabel;
                    break;
                case "TmpMin":
                    MyLabel = TmpMinLabel;
                    break;
                case "Pression":
                    MyLabel = PressionLabel;
                    break;
                case "Humidite":
                    MyLabel = HumiditeLabel;
                    break;
                case "Vent":
                    MyLabel = VentLabel;
                    break;
                case "Visibilite":
                    MyLabel = VisibiliteLabel;
                    break;
                case "Precipitation":
                    MyLabel = PrecipitationLabel;
                    break;
                case "Nebulosite":
                    MyLabel = NebulositeLabel;
                    break;

            }
           
            if ((MyLabel).Visibility == Visibility.Visible) MyLabel.Visibility = Visibility.Hidden;

        }

        private void NumericUpDown_MouseLeave(object sender, MouseEventArgs e)
        {
            NumericUpDown Variable = (NumericUpDown)sender;
            TextBlock MyLabel= TmpMaxLabel;
            switch (Variable.Name)
            {
                case "TmpMax":
                    MyLabel = TmpMaxLabel;
                    break;
                case "TmpMin":
                    MyLabel = TmpMinLabel;
                    break;
                case "Pression":
                    MyLabel = PressionLabel;
                    break;
                case "Humidite":
                    MyLabel = HumiditeLabel;
                    break;
                case "Vent":
                    MyLabel = VentLabel;
                    break;
                case "Visibilite":
                    MyLabel = VisibiliteLabel;
                    break;
                case "Precipitation":
                    MyLabel = PrecipitationLabel;
                    break;
                case "Nebulosite":
                    MyLabel = NebulositeLabel;
                    break;

            }
            if ((MyLabel).Visibility == Visibility.Hidden) MyLabel.Visibility = Visibility.Visible;
        }

        public DayData getDataFromWindow()
        {
            DayData data=new DayData();
            if(TmpMax.Value.ToString()!="") data.TempuratureMax = (sbyte)TmpMax.Value;
            if (TmpMin.Value.ToString() != "") data.TempuratureMin = (sbyte)TmpMin.Value;
            if (Humidite.Value.ToString() != "") data.Humidite = (byte)Humidite.Value;
            if (Precipitation.Value.ToString() != "") data.Precipitation = (float)Precipitation.Value;
            if (Pression.Value.ToString() != "") data.Pression = (float) Pression.Value;
            if (Nebulosite.Value.ToString() != "") data.Nebulosite = (byte)Nebulosite.Value;
            if (Vent.Value.ToString() != "") data.VitesseDuVent = (byte)Vent.Value;
            if (Visibilite.Value.ToString() != "") data.DistanceDeVisibilite = (float)Visibilite.Value;
            return data;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (IsValid())
            {
                DialogResult = true;
                deja = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Les champs tmpmax,tmpmin,humidite,pression,precipitation sont obligatoir");
            }
            
        }
        
        private bool IsValid()
        {
            return (TmpMax.Value.ToString() != "") && (TmpMin.Value.ToString() != "") && (Humidite.Value.ToString() != "") && (Pression.Value.ToString() != "") && (Precipitation.Value.ToString() != "");
        }
        

    }
}
