using System;
using System.IO;
using System.Windows;

namespace ProjetWPF
{
    class Conversion
    {
        /// <summary>Convertir est une methode de la classe Conversion .
        /// <para>Convertir les fichier excel de 48 wilaya nommée (i.csv) dans le dossier "DossierSource" en binaire dans le dossier "DossierDesstination"</para>
        /// </summary>
        public static void Convertir(string dossierSource,string dossierDesstination)
        {
            for (int i = 1; i <= 48; i++)
            {
                Convertir(dossierSource, dossierDesstination, i);
            }
        }
        /// <summary>Convertir est une methode de la classe Conversion .
        /// <para>Convertir un fichier excel de la  wilaya nommée (NumDeWilaya.csv) qui est dans le dossier "DossierSource" en binaire dans le dossier "DossierDesstination"</para>
        /// </summary>
        public static void Convertir(string dossierSource, string dossierDesstination, int numDeWilaya)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string ligne;
            DayData enreg = new DayData();
            DataWilaya donnesMeteo = new DataWilaya();
            try
            {
                StreamReader fichier = new StreamReader(dossierSource + "\\" + numDeWilaya + ".csv");
                while ((ligne = fichier.ReadLine()) != null)
                {
                    string[] substrings = ligne.Split(';');
                    string[] DateCompHeur = substrings[0].Split(' ');
                    string[] DateComp = DateCompHeur[0].Split('.');
                    DateTime UneDate = new DateTime(int.Parse(DateComp[2]), int.Parse(DateComp[1]), int.Parse(DateComp[0]));
                    enreg.DateDuJour = UneDate;
                    if (substrings[1].Length != 0) enreg.TempuratureMin = (sbyte)float.Parse(substrings[1]);
                    if (substrings[2].Length != 0) enreg.Pression = float.Parse(substrings[2]);
                    if (substrings[3].Length != 0) enreg.Humidite = byte.Parse(substrings[3]);
                    if (substrings[4].Length != 0)
                    {
                        string[] DirectVn = substrings[4].Split('.');
                        enreg.DirectionDuVent[0] = (Direction)int.Parse(DirectVn[0]);
                        enreg.DirectionDuVent[1] = (Direction)int.Parse(DirectVn[1]);
                    }

                    if (substrings[5].Length != 0) enreg.VitesseDuVent = byte.Parse(substrings[5]);
                    if (substrings[6].Length != 0) enreg.Nebulosite = (byte)float.Parse(substrings[6]);
                    if (substrings[7].Length != 0) enreg.DistanceDeVisibilite = float.Parse(substrings[7]);
                    if (substrings[8].Length != 0) enreg.Precipitation = float.Parse(substrings[8]);
                    if (substrings[9].Length != 0) enreg.Neige = (byte.Parse(substrings[9]) == 1) ? true : false;
                    if (substrings[10].Length != 0) enreg.TempuratureMax = (sbyte)float.Parse(substrings[10]);
                    enreg.Existe = true;
                    //L'ajout de l'instance dans la liste 
                    donnesMeteo.AjouterUnJour(enreg);
                    //DateActuel = DateActuel.AddDays(1);
                    enreg = new DayData();
                }
                fichier.Close();
                //La serialisation de la liste dans le fichier
                IOData.EcrireDonnesWilaya(donnesMeteo, dossierDesstination, numDeWilaya);

            }
            catch(Exception e)
            {
                Console.WriteLine("Erreur !!!!!!");
                MessageBox.Show(e.Message);
            }

        }
        /// <summary>AffichierBinaire est une methode de la classe Conversion .
        /// <para>Affichier les donées d'un fichier  binaire (Chemin) qui contier les données meterologique d'une wilaya</para>
        /// </summary>
        public static void AffichierBinaire(string dossierSource, int wilaya)
        {
            DataWilaya DonnesMeteo = IOData.LireDonnesWilaya(dossierSource, wilaya);           
            DonnesMeteo.Afficher();
            Console.WriteLine("Le nombre d'element:"+DonnesMeteo.NombreDeJour());
        }
        /// <summary>FichierPrediction est une methode de la classe Conversion .
        /// <para>Construction des fichier de prediction de la durée 'Duree' sous forme d'un (Tupel a deux dimention),apartir du fichier binaire de la 'Wilaya' qui se trouve dans 'DossierSource'</para>
        /// </summary>
        public static void FichierPrediction(string dossierSource, string dossierDesstination, int wilaya ,int duree)
        {
            IOData.EcrireDonnesWilayaPrediction((IOData.LireDonnesWilaya(dossierSource, wilaya)).ConstruireListePrediction(duree), dossierDesstination, wilaya, duree);
        }
    }
}





















