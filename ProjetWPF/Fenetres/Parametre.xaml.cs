using MahApps.Metro;
using ProjetWPF.Fenetres.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ProjetWPF.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour Parametre.xaml
    /// </summary>
    public partial class Parametre : UserControl
    {
        private int SelectededItem = 0;
        List<Grid> LesGrids;
        List<WrapPanel> LesWraps;        
        public TimeSpan Date = new TimeSpan(0,0,0);
        DispatcherTimer Timer = new DispatcherTimer();
        bool hasStarted = false;

        public Parametre()
        {

            List<string> nomDossier = IOData.GetSousDossier("../../Restauration");
            InitializeComponent();            
            NomWilaya.ItemsSource = Enum.GetValues(typeof(WilayaAlgerie)).Cast<WilayaAlgerie>();
            LesGrids = new List<Grid>
            {
                Theme,DateEtHaure,Sauvgarde,Restauration,Modification
            };
            LesWraps = new List<WrapPanel>
            {
                ThemeW,DateEtHaureW,SauvgardeW,RestaurationW,ModificationW
            };
            foreach (string dirs in nomDossier)
            {
                MyDataGrid.Items.Add(new DateFormat(dirs));
                MyDataGrid1.Items.Add(new DateFormat(dirs));
            }
            Date=IOData.LireDate();
            if (Date.Ticks == 0)
            {
                cal.IsEnabled = false;
                cb.IsChecked = true;
            }           
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now.Add(Date);
            box.Text = (dateTime).ToShortDateString()+" "+(dateTime).Hour+":"+ dateTime.Minute;
        }

        private void WrapPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int i = LesWraps.IndexOf((WrapPanel)sender);
            LesGrids[SelectededItem].Visibility = Visibility.Hidden;
            LesWraps[SelectededItem].Style = (Style)Application.Current.Resources["WrapSelection"]; 
            LesWraps[i].Style = (Style)Application.Current.Resources["WrapBleu"];
            if (SelectededItem == 1)
            {
                Timer.Stop();
            }
            SelectededItem = i;
            if (i == 1)
            {
                DateTime dateTime = DateTime.Now.Add(Date);
                box.Text = (dateTime).ToShortDateString() + " " + dateTime.ToShortTimeString();
                if (!hasStarted)
                {
                    hasStarted = true;
                    Timer.Tick += new EventHandler(Timer_Click);
                    Timer.Interval = new TimeSpan(0, 0, 30);
                    Timer.Start();
                }
            }
            LesGrids[i].Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MyDate.SelectedDate == null || NomWilaya.SelectedIndex == -1)
            {
                MessageBoxAlert.Show("Données Manquantes", "Entrée la wilaya et la date !");
            }
            else
            {
                Pass fen = new Pass();
                if ((bool)fen.ShowDialog())
                {
                    string[] date = (MyDate.Text).Split('/');
                    DateTime datetime = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                    int NumDewilaya = (int)((WilayaAlgerie)NomWilaya.SelectedItem) + 1;
                    Recuperartion fenetre = new Recuperartion();
                    if ((bool)fenetre.ShowDialog())
                    {
                        DayData donnée = fenetre.getDataFromWindow();
                        donnée.DateDuJour = datetime;
                        DataWilaya Wilaya = IOData.LireDonnesWilaya("../../Donnee", NumDewilaya);
                        Wilaya.ModifierUneDate(donnée);
                        IOData.EcrireDonnesWilaya(Wilaya, "../../Donnee", NumDewilaya);
                        MessageBoxAlert.Show("La modification est faite ! ", "");

                    }
                }


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pass fen = new Pass();
            if ((bool)fen.ShowDialog())
            {
                DateTime today = DateTime.Today;
                IOData.DirectoryCopy("../../Donnee", "../../Restauration/" + today.Year + "_" + today.Month + "_" + today.Day);
                List<string> nomDossier = IOData.GetSousDossier("../../Restauration");
                MyDataGrid1.Items.Clear();
                MyDataGrid.Items.Clear();
                foreach (string dirs in nomDossier)
                {
                    MyDataGrid.Items.Add(new DateFormat(dirs));
                    MyDataGrid1.Items.Add(new DateFormat(dirs));
                }
                MessageBoxAlert.Show("Fin de la sauvegarde.", "");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MyDataGrid.SelectedItems.Count < 1)
            {
                MessageBoxAlert.Show("Selectionez une ligne !", "");
            }
            else
            {
                DateFormat DossierDeSourceDeRestauration = (DateFormat)MyDataGrid.SelectedItems[0];
                Pass fen = new Pass();
                if ((bool)fen.ShowDialog())
                {
                    IOData.DirectoryCopy("../../Restauration/" + DossierDeSourceDeRestauration.Annee + "_" + DossierDeSourceDeRestauration.Mois + "_" + DossierDeSourceDeRestauration.Jour, "../../Donnee");
                    MessageBoxAlert.Show("Fin de la restauration.", "");
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MyDataGrid1.SelectedItems.Count < 1)
            {
                MessageBoxAlert.Show("Selectionez une ligne !", "");
            }
            else
            {
                DateFormat DossierDeSourceDeRestauration = (DateFormat)MyDataGrid1.SelectedItems[0];
                Pass fen = new Pass();
                if ((bool)fen.ShowDialog())
                {
                    IOData.DirectoryDelete("../../Restauration/" + DossierDeSourceDeRestauration.Annee + "_" + DossierDeSourceDeRestauration.Mois + "_" + DossierDeSourceDeRestauration.Jour);
                    List<string> nomDossier = IOData.GetSousDossier("../../Restauration");
                    MyDataGrid1.Items.Clear();
                    MyDataGrid.Items.Clear();
                    foreach (string dirs in nomDossier)
                    {
                        MyDataGrid.Items.Add(new DateFormat(dirs));
                        MyDataGrid1.Items.Add(new DateFormat(dirs));
                    }
                    MessageBoxAlert.Show("Fin de la suppression.", "");
                }
            }
        }

        private void Cb_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)cb.IsChecked)
            {
                Date = new TimeSpan(0, 0, 0);
                cal.IsEnabled = false;
                DateTime dateTime = DateTime.Now;
                box.Text = (dateTime).ToShortDateString() + " " +dateTime.ToShortTimeString();
                IOData.EcrireDate(Date);
            }
            else
            {
                cal.IsEnabled = true;
            }
        }
    

        private void Chang_Click(object sender, RoutedEventArgs e)
        {
            int theme;
            if (ComboTheme.SelectedIndex != -1)
            {
                if (ComboTheme.SelectedItem== Light)
                {
                    ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("AccentL"), ThemeManager.GetAppTheme("ThemeL"));
                    theme = 1;
                }
                else
                {
                    ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("AccentD"), ThemeManager.GetAppTheme("ThemeD"));
                    theme = 2;
                }
                IOData.EcrireDonnesTheme(theme);
            }
            
        }

        private void Cal_SelectedDateChanged(object sender, MahApps.Metro.Controls.TimePickerBaseSelectionChangedEventArgs<DateTime?> e)
        {
            if (cal.SelectedDate != null)
            {
               
                Date = (DateTime)cal.SelectedDate - DateTime.Now;
                DateTime dateTime = DateTime.Now.Add(Date);
                box.Text = (dateTime).ToShortDateString() + " " + dateTime.ToShortTimeString();
                IOData.EcrireDate(Date);
            }
        }
        private void Cal_SelectedTimeChanged(object sender, MahApps.Metro.Controls.TimePickerBaseSelectionChangedEventArgs<TimeSpan?> e)
        {
            if (cal.SelectedDate != null)
            {
                Date = (DateTime)cal.SelectedDate - DateTime.Now;
                DateTime dateTime = DateTime.Now.Add(Date);
                box.Text = (dateTime).ToShortDateString() + " " + dateTime.ToShortTimeString();
                IOData.EcrireDate(Date);
            }        
        }
    }
    public class DateFormat
    {
        public int Jour { get; set; }
        public int Mois { get; set; }
        public int Annee { get; set; }
        public DateFormat() { }
        public DateFormat(string DateFormatString)
        {
            string[] SubSting = DateFormatString.Split('_');
            if (SubSting.Length == 3)
            {
                Annee = int.Parse(SubSting[0]);
                Mois = int.Parse(SubSting[1]);
                Jour = int.Parse(SubSting[2]);
            }


        }
    }
}
