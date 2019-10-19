using MahApps.Metro.Controls;
using ProjetWPF.Fenetres;
using System;
using System.Windows;

namespace ProjetWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            if (!((favoris)Favo.Tag).UserData.IsEmpty())
            {
                Tuple<int, int> LaWilayaEtLaDuree = ((favoris)Favo.Tag).UserData.getFirstElement();
            }

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {

            HamburgerMenuIconItem ItemCliced = (HamburgerMenuIconItem)e.ClickedItem;
            if (ItemCliced.Label == "Prévision")
            {
                Prevision LaPageDePrévision = (Prevision)ItemCliced.Tag;
                if (((favoris)Favo.Tag).UserData.IsEmpty())
                {
                    MessageBox.Show("La liste des favoris est Vide");
                }
                else
                {
                    Tuple<int, int> LaWilayaEtLaDuree = ((favoris)Favo.Tag).UserData.getFirstElement();
                    if (LaPageDePrévision.NumWilaya != LaWilayaEtLaDuree.Item1)
                    {                       
                        DayData daymlm = IOData.LireDonnesJour("../../DonnesDunJour", LaWilayaEtLaDuree.Item1);
                        DateTime today = DateTime.Now.Add(IOData.LireDate());
                        LaPageDePrévision.NumWilaya = LaWilayaEtLaDuree.Item1;
                        LaPageDePrévision.Duree = LaWilayaEtLaDuree.Item2;
                        if (daymlm != null && !daymlm.Vide() && (daymlm.DateDuJour.Date == today.Date))
                        {
                            LaPageDePrévision.GridRec.Visibility = Visibility.Hidden;
                            LaPageDePrévision.flipView1.Visibility = Visibility.Visible;
                            LaPageDePrévision.BtmModifier.Visibility = Visibility.Visible;
                            LaPageDePrévision.Sauv.Visibility = Visibility.Visible;
                            LaPageDePrévision.Appliquer.Visibility = Visibility.Visible;
                            LaPageDePrévision.BtnAnnuler.Visibility = Visibility.Visible;
                            LaPageDePrévision.DounneesToday = daymlm;
                            LaPageDePrévision.ConstruireLesPagesDePreduction();
                        }
                        else
                        {
                            LaPageDePrévision.GridRec.Visibility = Visibility.Visible;
                            LaPageDePrévision.flipView1.Visibility = Visibility.Hidden;
                            LaPageDePrévision.BtnAnnuler.Visibility = Visibility.Hidden;
                            LaPageDePrévision.Sauv.Visibility = Visibility.Hidden;
                            LaPageDePrévision.Appliquer.Visibility = Visibility.Hidden;
                            LaPageDePrévision.BtmModifier.Visibility = Visibility.Hidden;
                        }
                    }
                    else if (LaPageDePrévision.Duree != LaWilayaEtLaDuree.Item2 && LaPageDePrévision.DounneesToday!=null && !LaPageDePrévision.DounneesToday.Vide())
                    {
                        LaPageDePrévision.Duree = LaWilayaEtLaDuree.Item2;
                        LaPageDePrévision.ConstruireLesPagesDePreduction();
                        LaPageDePrévision.Sauv.Visibility = Visibility.Visible;
                    }
                }
            }
            HamburgerMenuControl.Content = e.ClickedItem;
        }
    }
}