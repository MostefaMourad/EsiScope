using Microsoft.Win32;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using MahApps.Metro.Controls;
using ProjetWPF.Fenetres.UserControls.BtnChoix;
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
using MahApps.Metro.Controls.Dialogs;

namespace ProjetWPF.Fenetres.UserControls
{
    /// <summary>
    /// Logique d'interaction pour ControlStat.xaml
    /// </summary>
    public enum Month { Janvier, Février, Mars, Avril, Mai, Juin, Juillet, Aout, Septembre, Octobre, Nouvembre, Décembre }
    public partial class ControlStat : UserControl
    {
        int Wilaya { get; set; }
        int Variable { get; set; }
        int AnneeMon = 2018;
        int AnneeJour = 2018;
        int Mois = 1;
        bool MoisPresent = false;
        bool JourPrésent = false;
        string UniteMesure;
        string nomVariable;
        public ControlStat(int wilaya, int variable, string nomVariable, string UniteMesure)
        {
            InitializeComponent();
            Wilaya = wilaya;
            Variable = variable;
            NumWilaya.Text = Wilaya.ToString();
            this.UniteMesure = UniteMesure;
            NomWilaya.Text = ((WilayaAlgerie)(Wilaya - 1)).ToString();
            TempWilaya.Text = nomVariable + " moyenne ";
            if (variable == 1)
            {
                TabAnn.Items.Remove(TabViewAD);
                TabJour.Items.Remove(TabViewJD);
                TabMois.Items.Remove(TabViewMD);
            }
            StatAnnee();
            Grid3text.Text = (Month)(Mois - 1) + "," + AnneeJour;
            Btn3text.Text = (Month)(Mois - 1) + "," + AnneeJour;
            Grid2text.Text = AnneeMon + "";
            Bouton2text.Text = AnneeMon + "";
            this.nomVariable = nomVariable;
        }

        public void StatAnnee()
        {
            StatAnnee statAnnee = new StatAnnee(Variable, Wilaya);
            if (statAnnee.Tableau == null || statAnnee.Tableau.Count < 1)
            {
                MessageBoxAlert.Show("Manque des données", "Il y'a un manque de donnée dans cette wilaya!");
            }
            else
            {
                UserDate.DisplayDateStart = statAnnee.startDate;
                UserDate.DisplayDateEnd = statAnnee.endDate;
                for (int i = statAnnee.startDate.Year; i <= statAnnee.endDate.Year; i++)
                {
                    System.Windows.Controls.Button bnYear = new System.Windows.Controls.Button { Margin = new Thickness(3, 0, 3, 3), Style = this.FindResource("AccentedSquareButtonStyle") as System.Windows.Style, Content = i.ToString() };
                    bnYear.Click += BnYear_Click;
                    wrapYear.Children.Add(bnYear);
                }
                if (Variable != 1)
                {
                    Diagramme diagramme = new Diagramme(statAnnee.Tableau) { Height = 300, Width = 650 };
                    Courbe courbe = new Courbe(statAnnee.Tableau) { Height = 300, Width = 650 };
                    TabViewAD.Content = diagramme;
                    TabViewAC.Content = courbe;
                    Moy.Text = ((int)statAnnee.moyenne).ToString() + " " + UniteMesure;
                    Record2.Text = "Max  " + statAnnee.Max.Item4 + " " + UniteMesure;
                    Record1.Text = "Min  " + statAnnee.Min.Item4 + " " + UniteMesure;

                }
                else
                {
                    StatAnnee statAnnee1 = new StatAnnee(2, Wilaya);
                    Doublecourbe courbe = new Doublecourbe(statAnnee.Tableau, statAnnee1.Tableau) { Height = 300, Width = 650 };
                    TabViewAC.Content = courbe;
                    Moy.Text = ((int)((statAnnee.moyenne + statAnnee1.moyenne) / 2)).ToString() + " " + UniteMesure;
                    Record2.Text = "Max  " + statAnnee1.Max.Item4 + " " + UniteMesure + "       " + statAnnee1.Max.Item3 + " " + (Month)(statAnnee1.Max.Item2 - 1) + " " + statAnnee1.Max.Item1;
                    Record1.Text = "Min  " + statAnnee.Min.Item4 + " " + UniteMesure + "       " + statAnnee.Min.Item3 + " " + (Month)(statAnnee.Min.Item2 - 1) + " " + statAnnee.Min.Item1;

                }
            }

        }
        public void StatMois()
        {
            StatMois statMois = new StatMois(Variable, Wilaya, AnneeMon);
            if (statMois.Tableau == null || statMois.Tableau.Count < 1)
            {
                MessageBoxAlert.Show("Manque des données", "Il y'a un manque de donnée dans cet année!");
            }
            else
            {
                if (Variable != 1)
                {
                    Diagramme diagramme = new Diagramme(statMois.Tableau) { Height = 300, Width = 650 };
                    Courbe courbe = new Courbe(statMois.Tableau) { Height = 300, Width = 650 };
                    TabViewMD.Content = diagramme;
                    TabViewMC.Content = courbe;
                    Record2M.Text = "Max  " + statMois.Max.Item3 + " " + UniteMesure;
                    Record1M.Text = "Min  " + statMois.Min.Item3 + " " + UniteMesure;

                }
                else
                {
                    StatMois statMois1 = new StatMois(2, Wilaya, AnneeMon);
                    Doublecourbe courbe = new Doublecourbe(statMois.Tableau, statMois1.Tableau) { Height = 300, Width = 650 };
                    TabViewMC.Content = courbe;
                    Record2M.Text = "Max  " + statMois1.Max.Item3 + " " + UniteMesure + "       " + AnneeMon + " " + (Month)(statMois1.Max.Item2 - 1) + " " + statMois1.Max.Item1;
                    Record1M.Text = "Min  " + statMois.Min.Item3 + " " + UniteMesure + "       " + AnneeMon + " " + (Month)(statMois.Min.Item2 - 1) + " " + statMois.Min.Item1;
                }
                Grid2text.Text = AnneeMon + "";
                Bouton2text.Text = AnneeMon + "";
            }


        }
        public void StatJour()
        {
            StatJour statJour = new StatJour(Variable, Wilaya, AnneeJour, Mois);
            if (statJour.Tableau == null || statJour.Tableau.Count < 1)
            {
                MessageBoxAlert.Show("Manque des données", "Il y'a un manque de donnée dans ce mois!");
            }
            else
            {
                if (Variable != 1)
                {
                    Diagramme diagramme = new Diagramme(statJour.Tableau) { Height = 300, Width = 650 };
                    Courbe courbe = new Courbe(statJour.Tableau) { Height = 300, Width = 650 };
                    TabViewJD.Content = diagramme;
                    TabViewJC.Content = courbe;
                    Record2J.Text = "Max  " + statJour.Max.Item2 + " " + UniteMesure;
                    Record1J.Text = "Min  " + statJour.Min.Item2 + " " + UniteMesure;
                }
                else
                {
                    StatJour statJour1 = new StatJour(2, Wilaya, AnneeJour, Mois);
                    Doublecourbe courbe = new Doublecourbe(statJour.Tableau, statJour1.Tableau) { Height = 300, Width = 650 };
                    TabViewJC.Content = courbe;
                    Record2J.Text = "Max  " + statJour1.Max.Item2 + " " + UniteMesure + "       " + AnneeJour + " " + (Month)(Mois - 1) + " " + statJour1.Max.Item1;
                    Record1J.Text = "Min  " + statJour.Min.Item2 + " " + UniteMesure + "       " + AnneeJour + " " + (Month)(Mois - 1) + " " + statJour.Min.Item1;
                }

                Grid3text.Text = (Month)(Mois - 1) + "," + AnneeJour;
                Btn3text.Text = (Month)(Mois - 1) + "," + AnneeJour;
            }

        }

        private void Bouton1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid1.Visibility = Visibility.Visible;
            Grid2.Visibility = Visibility.Hidden;
            Grid3.Visibility = Visibility.Hidden;
            Bouton1.Visibility = Visibility.Hidden;
            Bouton2.Visibility = Visibility.Visible;
            Bouton3.Visibility = Visibility.Visible;
            TabViewA.Visibility = Visibility.Visible;
            TabViewM.Visibility = Visibility.Hidden;
            TabViewJ.Visibility = Visibility.Hidden;
            wrapYear.Visibility = Visibility.Hidden;
        }
        private void Bouton2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!MoisPresent) { StatMois(); MoisPresent = true; }
            Grid1.Visibility = Visibility.Hidden;
            Grid2.Visibility = Visibility.Visible;
            Grid3.Visibility = Visibility.Hidden;
            Bouton1.Visibility = Visibility.Visible;
            Bouton2.Visibility = Visibility.Hidden;
            Bouton3.Visibility = Visibility.Visible;
            TabViewA.Visibility = Visibility.Hidden;
            TabViewM.Visibility = Visibility.Visible;
            TabViewJ.Visibility = Visibility.Hidden;


        }
        private void Bouton3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!JourPrésent) { StatJour(); JourPrésent = true; }
            Grid1.Visibility = Visibility.Hidden;
            Grid2.Visibility = Visibility.Hidden;
            Grid3.Visibility = Visibility.Visible;
            Bouton1.Visibility = Visibility.Visible;
            Bouton2.Visibility = Visibility.Visible;
            Bouton3.Visibility = Visibility.Hidden;
            TabViewA.Visibility = Visibility.Hidden;
            TabViewM.Visibility = Visibility.Hidden;
            TabViewJ.Visibility = Visibility.Visible;
            wrapYear.Visibility = Visibility.Hidden;

        }

        private void BnYear_Click(object sender, RoutedEventArgs e)
        {
            int Ann = int.Parse(((System.Windows.Controls.Button)sender).Content.ToString());
            if (Ann != AnneeMon)
            {
                AnneeMon = Ann;
                StatMois();
            }
            wrapYear.Visibility = Visibility.Hidden;
        }

        private void UserDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (UserDate.SelectedDate != null)
            {
                DateTime m = (DateTime)UserDate.SelectedDate;
                if (m != null && (AnneeJour != m.Year || Mois != m.Month))
                {
                    AnneeJour = m.Year;
                    Mois = m.Month;
                    StatJour();
                }
            }
        }

        private void ChangeMonth_Click(object sender, RoutedEventArgs e)
        {
            wrapYear.Visibility = Visibility.Visible;
        }

        private void SaveA_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel file (*.xlsx)|*.xlsx",
                InitialDirectory = @"C:\Users\lenovo\Desktop\movies"
            };
            StatAnnee statAnnee = new StatAnnee(Variable, Wilaya);

            _Application excel = new _Excel.Application();
            if (saveFileDialog.ShowDialog() == true)
            {

                string filename = System.IO.Path.GetFileName(saveFileDialog.FileName);
                String path = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                Workbook wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = wb.Worksheets[1];

                ws.Cells[1, 1] = "Les statistiques Anuelles.";
                ws.Cells[2, 1] = "La Wilaya :";
                ws.Cells[2, 2] = ((WilayaAlgerie)(statAnnee.Wilaya - 1)).ToString();
                ws.Cells[3, 1] = "Le variable meteorologique :";
                ws.Cells[3, 2] = nomVariable;
                ws.Cells[5, 1] = "La valeur maximale :";
                ws.Cells[5, 2] = statAnnee.Max.Item4;
                ws.Cells[5, 3] = "Atteint le " + statAnnee.Max.Item1 + " " + ((Month)(statAnnee.Max.Item2 - 1)).ToString() + " " + statAnnee.Max.Item3;
                ws.Cells[6, 1] = "La valeur minimale :";
                ws.Cells[6, 2] = statAnnee.Min.Item4;
                ws.Cells[6, 3] = "Atteint le " + statAnnee.Min.Item1 + " " + ((Month)(statAnnee.Min.Item2 - 1)).ToString() + " " + statAnnee.Min.Item3;
                ws.Cells[8, 1] = "L'année ";
                ws.Cells[8, 2] = "La valeur moyenne ";
                int i = 9;
                foreach (Tuple<int, float> stat in statAnnee.Tableau)
                {

                    ws.Cells[i, 1] = stat.Item1;
                    ws.Cells[i, 2] = stat.Item2;
                    i++;

                }
                MessageBoxAlert.Show("Fin du sauvgarde", "Les Resultats sont bien enregistrés \n Le chemin du fichier : " + path + "\\" + filename);
                excel.DisplayAlerts = false;
                wb.SaveAs(path + "\\" + filename);
                wb.Close();
                excel.Quit();

            }
        }

        private void SaveM_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel file (*.xlsx)|*.xlsx",
                InitialDirectory = @"C:\Users\lenovo\Desktop\movies"
            };
            StatMois statMois = new StatMois(Variable, Wilaya, AnneeMon);

            _Application excel = new _Excel.Application();
            if (saveFileDialog.ShowDialog() == true)
            {

                string filename = System.IO.Path.GetFileName(saveFileDialog.FileName);
                String path = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                Workbook wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = wb.Worksheets[1];

                ws.Cells[1, 1] = "Les statistiques mensuelles.";
                ws.Cells[2, 1] = "La Wilaya :";
                ws.Cells[2, 2] = ((WilayaAlgerie)(statMois.Wilaya - 1)).ToString();
                ws.Cells[3, 1] = "Le variable meteorologique :";
                ws.Cells[3, 2] = nomVariable;
                ws.Cells[4, 1] = "L'année :";
                ws.Cells[4, 2] = statMois.Annee;
                ws.Cells[6, 1] = "La valeur maximale :";
                ws.Cells[6, 2] = statMois.Max.Item3;
                ws.Cells[6, 3] = "Atteint le " + statMois.Max.Item1 + " " + ((Month)(statMois.Max.Item2 - 1)).ToString() + " " + statMois.Annee;
                ws.Cells[7, 1] = "La valeur minimale :";
                ws.Cells[7, 2] = statMois.Min.Item3;
                ws.Cells[7, 3] = "Atteint le " + statMois.Min.Item1 + " " + ((Month)(statMois.Min.Item2 - 1)).ToString() + " " + statMois.Annee;
                ws.Cells[9, 1] = "Le Mois ";
                ws.Cells[9, 2] = "La valeur moyenne ";
                int i = 10;
                foreach (Tuple<int, float> stat in statMois.Tableau)
                {

                    ws.Cells[i, 1] = ((Month)(stat.Item1 - 1)).ToString();
                    ws.Cells[i, 2] = stat.Item2;
                    i++;

                }
                MessageBoxAlert.Show("Fin du sauvgarde", "Les Resultats sont bien enregistrés \n Le chemin du fichier : " + path + "\\" + filename);
                excel.DisplayAlerts = false;
                wb.SaveAs(path + "\\" + filename);
                wb.Close();
                excel.Quit();

            }
        }

        private void SaveJ_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel file (*.xlsx)|*.xlsx",
                InitialDirectory = @"C:\Users\lenovo\Desktop\movies"
            };
            StatJour statJour = new StatJour(Variable, Wilaya, AnneeJour, Mois);

            _Application excel = new _Excel.Application();
            if (saveFileDialog.ShowDialog() == true)
            {

                string filename = System.IO.Path.GetFileName(saveFileDialog.FileName);
                String path = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                Workbook wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = wb.Worksheets[1];

                ws.Cells[1, 1] = "Les statistiques journaliere.";
                ws.Cells[2, 1] = "La Wilaya :";
                ws.Cells[2, 2] = ((WilayaAlgerie)(statJour.Wilaya - 1)).ToString();
                ws.Cells[3, 1] = "Le variable meteorologique :";
                ws.Cells[3, 2] = nomVariable;
                ws.Cells[4, 1] = "L'année :";
                ws.Cells[4, 2] = statJour.Annee;
                ws.Cells[5, 1] = "Le mois :";
                ws.Cells[5, 2] = ((Month)(statJour.Mois - 1)).ToString();
                ws.Cells[7, 1] = "La valeur maximale :";
                ws.Cells[7, 2] = statJour.Max.Item2;
                ws.Cells[7, 3] = "Atteint le " + statJour.Max.Item1 + " " + ((Month)(statJour.Mois - 1)).ToString();
                ws.Cells[8, 1] = "La valeur minimale :";
                ws.Cells[8, 2] = statJour.Min.Item2;
                ws.Cells[8, 3] = "Atteint le " + statJour.Min.Item1 + " " + ((Month)(statJour.Mois - 1)).ToString();
                ws.Cells[10, 1] = "Le jour";
                ws.Cells[10, 2] = "La valeur ";
                int i = 11;
                foreach (Tuple<int, float> stat in statJour.Tableau)
                {

                    ws.Cells[i, 1] = stat.Item1;
                    ws.Cells[i, 2] = stat.Item2;
                    i++;

                }
                MessageBoxAlert.Show("Fin du sauvgarde", "Les Resultats sont bien enregistrés \n Le chemin du fichier : " + path + "\\" + filename);
                excel.DisplayAlerts = false;
                wb.SaveAs(path + "\\" + filename);
                wb.Close();
                excel.Quit();
            }
        }
    }
}
