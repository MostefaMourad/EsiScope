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

namespace ProjetWPF.Fenetres
{
    /// <summary>
    /// Logique d'interaction pour mine.xaml
    /// </summary>
    public enum WilayaAlgerie
    {
        Adrar
         , Chlef, Laghouat, Oum_ElBouaghi, Batna, Béjaïa, Biskra,
        Béchar, Blida, Bouira, Tamanrasset, Tébessa, Tlemcen, Tiaret, TiziOuzou, Alger,
        Djelfa, Jijel, Sétif, Saïda, Skikda, SidiBelAbbès, Annaba,
        Guelma, Constantine, Médéa, Mostaganem, MSila, Mascara,
        Ouargla, Oran, El_Bayadh, Illizi, B_B_Arreridj, Boumerdès,
        ElTarf, Tindouf, Tissemsilt, ElOued,
        Khenchla, Souk_Ahras, Tipaza, Mila, Aïn_Defla, Naâma, AïnTémouchent, Ghardaïa, Relizane
    }
    public partial class favoris : UserControl
    {
        public DonnesUtilisateur UserData;

        public favoris()
        {
            UserData = IOData.LireDonnesUtilisateur("../../DonneesUtilisateurs");
            InitializeComponent();
            NomWilaya.ItemsSource = Enum.GetValues(typeof(WilayaAlgerie)).Cast<WilayaAlgerie>();
            Draw();

        }
        void Draw()
        {
            Tuple<int, int> l;
            l = UserData.PrefWilayaPeriode[0];
            GridFavo gridFaco = new GridFavo
            {
                Height = 150,
                Width = 250
            };
            Thickness margin = gridFaco.Margin;
            margin.Left = 40;
            margin.Top = 25;
            gridFaco.Margin = margin;
            gridFaco.Wilaya.Text = ((WilayaAlgerie)(l.Item1 - 1)).ToString();
            gridFaco.Prevision.Text = "Prévision dans " + l.Item2 + " jours";
            gridFaco.Supp.Uid = 0 + "";
            gridFaco.Supp.MouseLeftButtonDown += Supp_MouseLeftButtonUp;
            gridFaco.MouseDoubleClick += GridFavo_MouseDoubleClick;
            WrapDefalt.Children.Add(gridFaco);
            for (int i = 1; i < UserData.PrefWilayaPeriode.Count; i++)
            {
                l = UserData.PrefWilayaPeriode[i];
                GridFavo m = new GridFavo
                {
                    Height = 150,
                    Width = 250
                };
                Thickness margin1 = m.Margin;
                margin1.Left = 40;
                margin1.Top = 25;
                m.Margin = margin1;
                m.Wilaya.Text = ((WilayaAlgerie)(l.Item1 - 1)).ToString();
                m.Prevision.Text = "Prévision dans " + l.Item2 + " jours";
                m.Supp.Uid = i + "";
                m.Supp.MouseLeftButtonDown += Supp_MouseLeftButtonUp;
                m.MouseDoubleClick += GridFavo_MouseDoubleClick;
                WrapNonDefalt.Children.Add(m);
            }

            if (UserData.PrefWilayaPeriode.Count < 7)
            {
                GridAjout m = new GridAjout
                {
                    Height = 150,
                    Width = 250
                };
                Thickness margin1 = m.Margin;
                margin.Left = 40;
                margin.Top = 25;
                m.Margin = margin;
                m.MouseLeftButtonDown += AfficherLaSaisie;
                WrapNonDefalt.Children.Add(m);
            }
        }
        public void Supp_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            if (UserData.PrefWilayaPeriode.Count != 1)
            {
                int i = int.Parse(((Ellipse)sender).Uid);
                IOData.SupprimerFichierPrevision("../../DonneePre", UserData.PrefWilayaPeriode[i].Item1, UserData.PrefWilayaPeriode[i].Item2);
                UserData.PrefWilayaPeriode.RemoveAt(i);
                IOData.EcrireDonnesUtilisateur(UserData, "../../DonneesUtilisateurs");
                WrapNonDefalt.Children.Clear();
                WrapDefalt.Children.Clear();
                Draw();
            }

        }
        public void AfficherLaSaisie(object sender, RoutedEventArgs e)
        {
            Recup.Visibility = Visibility.Visible;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Recup.Visibility = Visibility.Hidden;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if (NomDuree.SelectedIndex != -1 && NomWilaya.SelectedIndex != -1)
            {
                int duree = int.Parse(NomDuree.Text);
                int wilayaSelect = (int)((WilayaAlgerie)NomWilaya.SelectedItem) + 1;
                if ((UserData.PrefWilayaPeriode.Count < 7) && (UserData.PrefWilayaPeriode.FindIndex(a => (a.Item1 == wilayaSelect) && (a.Item2 == duree)) < 0))
                {
                    DataWilaya DonéesAConvertire = IOData.LireDonnesWilaya("../../Donnee", wilayaSelect);
                    IOData.EcrireDonnesWilayaPrediction(DonéesAConvertire.ConstruireListePrediction(duree), "../../DonneePre", wilayaSelect, duree);
                    UserData.Add(wilayaSelect, duree);
                    IOData.EcrireDonnesUtilisateur(UserData, "../../DonneesUtilisateurs");
                    Recup.Visibility = Visibility.Hidden;
                    WrapNonDefalt.Children.Clear();
                    WrapDefalt.Children.Clear();
                    Draw();
                }

            }
        }

        private void GridFavo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int i = int.Parse(((GridFavo)sender).Supp.Uid);
            if (i != 0)
            {
                UserData.PrefWilayaPeriode.Insert(0, UserData.PrefWilayaPeriode[i]);
                UserData.PrefWilayaPeriode.RemoveAt(i + 1);
                IOData.EcrireDonnesUtilisateur(UserData, "../../DonneesUtilisateurs");
                WrapNonDefalt.Children.Clear();
                WrapDefalt.Children.Clear();
                Draw();
            }

        }
    }


    [Serializable]
    public class DonnesUtilisateur
    {
        public List<Tuple<int, int>> PrefWilayaPeriode { get; set; }
        public DonnesUtilisateur()
        {
            PrefWilayaPeriode = new List<Tuple<int, int>>();
        }
        public void Add(int wilaya, int d)
        {
            PrefWilayaPeriode.Add(new Tuple<int, int>(wilaya, d));
        }
        public Tuple<int, int> getFirstElement() => PrefWilayaPeriode[0];
        public bool IsEmpty() => PrefWilayaPeriode.Count < 1;
        public string afficher()
        {
            string m = "";

            if (PrefWilayaPeriode != null)
            {
                foreach (Tuple<int, int> l in PrefWilayaPeriode)
                {
                    m += "Wilaya: " + l.Item1 + "Durees: " + l.Item2 + '\n';
                }
            }
            return m;
        }
    }
}
