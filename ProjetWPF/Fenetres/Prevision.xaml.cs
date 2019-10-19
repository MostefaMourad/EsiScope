using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using ProjetWPF.Fenetres.UserControls;

namespace ProjetWPF.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Prevision.xaml
    /// </summary>
    public partial class Prevision : UserControl
    {
        public bool InfoPresente { get; private set; }
        public DayData DounneesToday { get; set; }
        public int NumWilaya { get; set; }
        public int Duree { get; set; }
        List<Tuple<float, DayData>> ListeDesPrediction { get; set; }


        public Prevision()
        {
            NumWilaya = 0;
            InitializeComponent();
            ComboVent.ItemsSource = Enum.GetValues(typeof(Direction)).Cast<Direction>();

        }

        public void SetElements(ref AffichageJour LaPage, Tuple<float, DayData> DataDuJour,int wilaya)
        {
            if(!DataDuJour.Item2.VideTempuratureMax() && ((bool)ToggTempurature.IsChecked))
            {
                LaPage.TempMax.Content = DataDuJour.Item2.TempuratureMax + " °";
            }
            else
            {
                LaPage.TmpMaxGrid.Visibility = Visibility.Hidden;
            }

            if (!DataDuJour.Item2.VideTempuratureMin() && ((bool)ToggTempurature.IsChecked))
            {
                LaPage.TempMin.Content = DataDuJour.Item2.TempuratureMin + " °";
            }
            else
            {
                LaPage.TmpMinGrid.Visibility = Visibility.Hidden;
            }

            if (!DataDuJour.Item2.VideHumidite() && ((bool)ToggHumidite.IsChecked))
            {
                LaPage.HumiditeBar.Value = DataDuJour.Item2.Humidite;
                LaPage.HumiditeLabel.Content = DataDuJour.Item2.Humidite + " %";
            }
            else
            {
                LaPage.HumiditeGrid.Visibility = Visibility.Hidden;
            }

            if (!DataDuJour.Item2.VidePrecipitation() && ((bool)ToggPrecipitation.IsChecked))
            {
                LaPage.PrecipitationBar.Value = DataDuJour.Item2.Precipitation;
                LaPage.PrecipitationLabel.Content = DataDuJour.Item2.Precipitation + " mm";
            }
            else
            {
                LaPage.PrecipitationGrid.Visibility = Visibility.Hidden;
            }
            if (!DataDuJour.Item2.VideNebulosite() && ((bool)ToggNebulosite.IsChecked))
            {
                LaPage.NubulisiteBar.Value = DataDuJour.Item2.Nebulosite;
                LaPage.NubulisiteLabel.Content = DataDuJour.Item2.Nebulosite + " %";
            }
            else
            {
                LaPage.NubulositeGrig.Visibility = Visibility.Hidden;
            }


            if (!DataDuJour.Item2.VidePression() && ((bool)ToggPression.IsChecked))
            {
                LaPage.PressionBar.Value = DataDuJour.Item2.Pression;
                LaPage.PressionLabel.Content = DataDuJour.Item2.Pression;
            }
            else
            {
                LaPage.PressionGrid.Visibility = Visibility.Hidden;
            }

            if (!DataDuJour.Item2.VideDistanceDeVisibilite() && ((bool)ToggVisibilite.IsChecked))
            {
                LaPage.VisibiliteBar.Value = DataDuJour.Item2.DistanceDeVisibilite;
                LaPage.VisibiliteLabel.Content = DataDuJour.Item2.DistanceDeVisibilite + " Km";

            }
            else
            {
                LaPage.DistanceDeVisibiliteGrid.Visibility = Visibility.Hidden;
            }
            if(!DataDuJour.Item2.VideVitesseDuVent()  && ((bool)ToggVent.IsChecked))
            {
                LaPage.LaBoussole.SetValue(DataDuJour.Item2.VitesseDuVent,DataDuJour.Item2.DirectionDuVent[0]);
            }
            else
            {
                LaPage.LaBoussole.Visibility = Visibility.Hidden;
            }
            LaPage.WilayaLabel.Content = (WilayaAlgerie)(wilaya-1);
            LaPage.DureeLabel.Content = "Prevision dans "+Duree+" jour";
           //LaPage.DateLabel.Content = DataDuJour.Item2.DateDuJour.ToLongDateString();
            LaPage.SimilariteGauge.Value =(int)DataDuJour.Item1;


        }

        public  void ConstruireLesPagesDePreduction()
        {
            InfoPresente = true;
            List<AffichageJour> ListeDesPages = new List<AffichageJour>();
            DataWilayaPrediction DonnesMeteo = IOData.LireDonnesWilayaPrediction(@"..\..\DonneePre",NumWilaya,Duree);
            if (DonnesMeteo == null)
            {
                MessageBoxAlert.Show("Fin De la restauration.", "Les Donées de la wilaya : " + NumWilaya + " et la durée: " + Duree + "n'existe pas !");
            }           
            else
            {
                ListeDesPrediction = DonnesMeteo.CalculerPreduction(DounneesToday);
                for (int i = 0; (i < 10 && i < ListeDesPrediction.Count); i++)
                {
                    AffichageJour LaPage = new AffichageJour();
                    SetElements(ref LaPage, ListeDesPrediction[i], NumWilaya);
                    ListeDesPages.Add(LaPage);
                }
                flipView1.ItemsSource = ListeDesPages;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (flipView1.ItemsSource != null)
            {
                List<AffichageJour> ListeDesPages = (List<AffichageJour>)flipView1.ItemsSource;
                foreach (AffichageJour page in ListeDesPages)
                {
                    if ((bool)ToggTempurature.IsChecked)
                    {
                        page.TmpMaxGrid.Visibility = Visibility.Visible;
                        page.TmpMinGrid.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        page.TmpMaxGrid.Visibility = Visibility.Hidden;
                        page.TmpMinGrid.Visibility = Visibility.Hidden;
                    }
                    if ((bool)ToggHumidite.IsChecked)
                    {
                        page.HumiditeGrid.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        page.HumiditeGrid.Visibility = Visibility.Hidden; ;
                    }
                    if ((bool)ToggNebulosite.IsChecked)
                    {
                        page.NubulositeGrig.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        page.NubulositeGrig.Visibility = Visibility.Hidden;
                    }
                    if ((bool)ToggPrecipitation.IsChecked)
                    {
                        page.PrecipitationGrid.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        page.PrecipitationGrid.Visibility = Visibility.Hidden; ;
                    }
                    if ((bool)ToggPression.IsChecked)
                    {
                        page.PressionGrid.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        page.PressionGrid.Visibility = Visibility.Hidden; ;
                    }
                    if ((bool)ToggVisibilite.IsChecked)
                    {
                        page.DistanceDeVisibiliteGrid.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        page.DistanceDeVisibiliteGrid.Visibility = Visibility.Hidden;
                    }
                    if ( ((bool)ToggVent.IsChecked))
                    {
                        page.LaBoussole.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        page.LaBoussole.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private void NumericUpDown_MouseEnter(object sender, MouseEventArgs e)
        {
            NumericUpDown Variable = (NumericUpDown)sender;
            TextBlock MyLabel = TmpMaxLabel;
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
            TextBlock MyLabel = TmpMaxLabel;
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

        private void Button_Click_D(object sender, RoutedEventArgs e)
        {

            if (IsValid())
            {
                DayData data = new DayData();
                if (TmpMax.Value.ToString() != "") data.TempuratureMax = (sbyte)TmpMax.Value; 
                if (TmpMin.Value.ToString() != "") data.TempuratureMin = (sbyte)TmpMin.Value;
                if (Humidite.Value.ToString() != "") data.Humidite = (byte)Humidite.Value;
                if (Precipitation.Value.ToString() != "") data.Precipitation = (float)Precipitation.Value;
                if (Pression.Value.ToString() != "") data.Pression = (float)Pression.Value;
                if (Nebulosite.Value.ToString() != "") data.Nebulosite = (byte)Nebulosite.Value;
                if (Vent.Value.ToString() != "") data.VitesseDuVent = (byte)Vent.Value;
                if (Visibilite.Value.ToString() != "") data.DistanceDeVisibilite = (float)Visibilite.Value;
                if (ComboVent.SelectedIndex != -1) data.DirectionDuVent[0] = ((Direction)ComboVent.SelectedItem);
                if (ComboNeige.SelectedIndex != -1 && ComboNeige.SelectedItem== oui) { data.Neige = true;}
                data.DateDuJour = DateTime.Today;
                DounneesToday = data;
                IOData.EcrireDonnesJour(DounneesToday, "../../DonnesDunJour", NumWilaya);
                GridRec.Visibility = Visibility.Hidden;
                flipView1.Visibility = Visibility.Visible;
                BtmModifier.Visibility = Visibility.Visible;
                ConstruireLesPagesDePreduction();
                Sauv.Visibility = Visibility.Visible;
                Appliquer.Visibility = Visibility.Visible;
            }
            else
            {           
                MessageBoxAlert.Show("Manque des données", "Les champs tmpmax,tmpmin,humidite,pression,precipitation sont obligatoir");
            }

        }

        private bool IsValid()
        {
            return (TmpMax.Value.ToString() != "") && (TmpMin.Value.ToString() != "") && (Humidite.Value.ToString() != "") && (Pression.Value.ToString() != "") && (Precipitation.Value.ToString() != "");
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            BtmModifier.Visibility = Visibility.Hidden;
            BtnAnnuler.Visibility = Visibility.Visible;
            GridRec.Visibility = Visibility.Visible;
            flipView1.Visibility = Visibility.Hidden;
            Sauv.Visibility = Visibility.Hidden;
            Appliquer.Visibility = Visibility.Hidden;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            GridRec.Visibility = Visibility.Hidden;
            flipView1.Visibility = Visibility.Visible;
            Sauv.Visibility = Visibility.Visible;
            Appliquer.Visibility = Visibility.Visible;
            BtmModifier.Visibility = Visibility.Visible;
        }

        private void Sauv_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel file (*.xlsx)|*.xlsx",
                InitialDirectory = @"C:\Users\zaki\Desktop\ProjetWPF\ProjetWPF\ResultatsPrevision"
            };
            _Application excel = new _Excel.Application();
            if (saveFileDialog.ShowDialog() == true)
            {

                string filename = System.IO.Path.GetFileName(saveFileDialog.FileName);
                String path = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);


                MessageBox.Show("Les Resultats sont bien enregistrés \n Le chemin du fichier : " + path + "\\" + filename);
                Workbook wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = wb.Worksheets[1];

                ws.Cells[1, 1] = "Les resultats de la prévision.";
                ws.Cells[2, 1] = "La Wilaya :";
                ws.Cells[2, 2] = ((WilayaAlgerie)(NumWilaya - 1)).ToString();
                ws.Cells[3, 1] = "La date :";
                ws.Cells[3, 2] = DounneesToday.DateDuJour.AddDays(Duree);
                ws.Cells[5, 1] = "Sumilaritie '%' ";
                ws.Cells[5, 2] = "TemperatureMin";
                ws.Cells[5, 3] = "TemperatureMax";
                ws.Cells[5, 4] = "Pression";
                ws.Cells[5, 5] = "Humidite";
                ws.Cells[5, 6] = "Precipitation";
                ws.Cells[5, 7] = "Nebulosite ";
                ws.Cells[5, 8] = "Vitesse du vent";
                ws.Cells[5, 9] = "Direction du vent";
                ws.Cells[5, 10] = "Distance de visibilite";
                ws.Cells[5, 11] = "Neige";
                int i = 6;
                foreach (Tuple<float, DayData> jour in ListeDesPrediction)
                {

                    ws.Cells[i, 1] = jour.Item1;
                    if (!jour.Item2.VideTempuratureMin()) ws.Cells[i, 2] = jour.Item2.TempuratureMin;
                    if (!jour.Item2.VideTempuratureMax()) ws.Cells[i, 3] = jour.Item2.TempuratureMax;
                    if (!jour.Item2.VidePression()) ws.Cells[i, 4] = jour.Item2.Pression;
                    if (!jour.Item2.VideHumidite()) ws.Cells[i, 5] = jour.Item2.Humidite;
                    if (!jour.Item2.VidePrecipitation()) ws.Cells[i, 6] = jour.Item2.Precipitation;
                    if (!jour.Item2.VideNebulosite()) ws.Cells[i, 7] = jour.Item2.Nebulosite;
                    if (!jour.Item2.VideVitesseDuVent()) ws.Cells[i, 8] = jour.Item2.VitesseDuVent;
                    ws.Cells[i, 9] = (jour.Item2.DirectionDuVent[0]).ToString();
                    if (!jour.Item2.VideDistanceDeVisibilite()) ws.Cells[i, 10] = jour.Item2.DistanceDeVisibilite;
                    if (!jour.Item2.VideNeige()) ws.Cells[i, 11] = jour.Item2.Neige;
                    i++;
                    if (i == 16) break;
                }
                excel.DisplayAlerts = false;
                wb.SaveAs(path + "\\" + filename);
                wb.Close();
                excel.Quit();

            }
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (this.ActualWidth<= 750)
            {
                row1.Width = new GridLength(0, GridUnitType.Star);
            }
            else
            {
                row1.Width = new GridLength(31, GridUnitType.Star);
            }
        }
    }
}



