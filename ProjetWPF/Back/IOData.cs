using ProjetWPF.Fenetres;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace ProjetWPF
{
    class IOData
    {
        private IOData() { }
        /// <summary>EcrireDonnesWilaya est une methode statique de la classe IOData .
        /// <para>Ecrure l'objet "donnesMeteo" dans un fichier qui sera ciéer dans le dossier "dossier"</para>
        /// </summary>
        public static void EcrireDonnesWilaya(DataWilaya donnesMeteo,string dossier, int numDeWilaya)
        {
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = File.Open(dossier + "\\" + numDeWilaya + ".bin", FileMode.Create))
                {
                    binaryFormatter.Serialize(stream, donnesMeteo);
                }
            }
            catch
            {
                Console.WriteLine("Erreur !!!");
            }
            
        }

        

        /// <summary>LireDonnesWilaya est une methode statique de la classe IOData .
        /// <para>Lire un objet de type DataWilaya de la wilaya numero "numDeWilaya"</para>
        /// </summary>
        public static DataWilaya LireDonnesWilaya(string dossier, int numDeWilaya)
        {
            DataWilaya donnesMeteo= new DataWilaya();
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            try
            {
                using (Stream stream = File.Open(dossier + "/" + numDeWilaya + ".bin", FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    donnesMeteo = (DataWilaya)binaryFormatter.Deserialize(stream);
                }
            }
            catch(Exception r)
            {
                MessageBox.Show(r.Message);
            }         
            return donnesMeteo;
        }
        /// <summary>EcrireDonnesWilayaPrediction est une methode statique de la classe IOData .
        /// <para>Ecrure l'objet "donnesMeteoPrediction" dans un fichier qui sera ciéer dans le dossier "dossier" de la wilaya "numDeWilaya" et la durée "duree"</para>
        /// </summary>
        public static void EcrireDonnesWilayaPrediction(DataWilayaPrediction donnesMeteoPrediction, string dossier, int numDeWilaya,int duree)
        {
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            try
            {
                using (Stream stream = File.Open(dossier + "\\" + numDeWilaya + "pre_" + duree + ".bin", FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, donnesMeteoPrediction);
                }
            }
            catch
            {
                MessageBox.Show("Les Donées de la wilaya : "+numDeWilaya+" et la durée: "+duree+"n'existe pas !");
            }

        }
        /// <summary>EcrireDonnesWilayaPrediction est une methode statique de la classe IOData .
        /// <para>Lire un objet de type DataWilayaPrediction de la wilaya numero "numDeWilaya" et la durée "duree"</para>
        /// </summary>
        public static DataWilayaPrediction LireDonnesWilayaPrediction(string dossier, int numDeWilaya, int duree)
        {
            DataWilayaPrediction donnesMeteo =null;
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            try
            {
                using (Stream stream = File.Open(dossier + "\\" + numDeWilaya + "pre_" + duree + ".bin", FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    donnesMeteo = (DataWilayaPrediction)binaryFormatter.Deserialize(stream);
                }
            }
            catch
            {
                Console.WriteLine("Erreur!!!");
            }
            return donnesMeteo;
        }



        public static void EcrireDonnesJour(DayData donnesMeteo, string dossier, int Wilaya)
        {
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = File.Open(dossier + "\\Donneesaujourdhui"+Wilaya+ ".bin", FileMode.Create))
                {
                    binaryFormatter.Serialize(stream, donnesMeteo);
                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message);
            }

        }
        /// <summary>LireDonnesWilaya est une methode statique de la classe IOData .
        /// <para>Lire un objet de type DataWilaya de la wilaya numero "numDeWilaya"</para>
        /// </summary>
        public static DayData LireDonnesJour(string dossier, int Wilaya)
        {
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            DayData donnesMeteo = new DayData();
            try
            {
                using (Stream stream = File.Open(dossier + "\\Donneesaujourdhui" + Wilaya  +".bin", FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    donnesMeteo = (DayData)binaryFormatter.Deserialize(stream);
                }
            }
            catch 
            {
                donnesMeteo = new DayData();
            }
            return donnesMeteo;
        }


        public static void EcrireDonnesUtilisateur(DonnesUtilisateur userData, string dossier)
        {
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = File.Open(dossier + "\\User.bin", FileMode.Create))
                {
                    binaryFormatter.Serialize(stream, userData);
                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message);
            }

        }


        public static DonnesUtilisateur LireDonnesUtilisateur(string dossier)
        {
            
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            DonnesUtilisateur userData = new DonnesUtilisateur();
            try
            {
                using (Stream stream1 = File.Open(dossier + "\\User.bin", FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    userData = (DonnesUtilisateur)binaryFormatter.Deserialize(stream1);
                }
            }
            catch 
            {
                userData = new DonnesUtilisateur();
                using (Stream stream = File.Open(dossier + "\\User.bin", FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, userData);
                }
            }
            return userData;
        }

        public static List<string> GetSousDossier(string sourceDirName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            List<string> Resultat = new List<string>() ;
            dir.GetDirectories();
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (dir.Exists)
            {
                foreach (DirectoryInfo d in dirs)
                {
                    Resultat.Add(d.Name);
                }
            }
            return Resultat;
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            }
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }
        }

        public static void DirectoryDelete(string dossier)
        {
            if (Directory.Exists(dossier))
            {
                Directory.Delete(dossier, true);
            }
        }

        public static void EcrireMotDePasse(string MotDePasse)
        {
            string dossier = "../../DonneesUtilisateurs";
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = File.Open(dossier+"/UserMP.bin", FileMode.Create))
                {
                    binaryFormatter.Serialize(stream, MotDePasse);
                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message);
            }

        }
        public static bool Autintification(string MotDePasse)
        {
            string dossier = "../../DonneesUtilisateurs";
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            string leMotDePasse;
            try
            {
                using (Stream stream1 = File.Open(dossier + "/UserMP.bin", FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    leMotDePasse = (string)binaryFormatter.Deserialize(stream1);                    
                    if(leMotDePasse== MotDePasse) return true; 
                }
            }
            catch
            {
                leMotDePasse = "";
                using (Stream stream = File.Open(dossier + "/UserMP.bin", FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, leMotDePasse);
                }
                return false;
            }
            return false;
        }
        public static void SupprimerFichierPrevision(string dossier, int numDeWilaya, int duree)
        {
            if (File.Exists(dossier + "\\" + numDeWilaya + "pre_" + duree + ".bin"))
            {
                File.Delete(dossier + "\\" + numDeWilaya + "pre_" + duree + ".bin");
            }
        }



        public static void EcrireDonnesTheme(int i)
        {
            string dossier = "../../DonneesUtilisateurs";
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = File.Open(dossier + "/ThemeIndex.bin", FileMode.Create))
                {
                    binaryFormatter.Serialize(stream, i);
                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message);
            }

        }


        public static int LireDonnesTheme()
        {
            string dossier = "../../DonneesUtilisateurs";
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            int userData = 0;
            try
            {
                using (Stream stream1 = File.Open(dossier + "\\ThemeIndex.bin", FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    userData = (int)binaryFormatter.Deserialize(stream1);
                }
            }
            catch
            {
                using (Stream stream = File.Open(dossier + "\\ThemeIndex.bin", FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, userData);
                }
            }
            return userData;
        }


        public static void EcrireDate(TimeSpan date)
        {
            string dossier = "../../DonneesUtilisateurs";
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = File.Open(dossier + "/Date.bin", FileMode.Create))
                {
                    binaryFormatter.Serialize(stream, date);
                }
            }
            catch (Exception em)
            {
                MessageBox.Show(em.Message);
            }

        }


        public static TimeSpan LireDate()
        {
            string dossier = "../../DonneesUtilisateurs";
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
            }
            TimeSpan userData = new TimeSpan(0,0,0);
            try
            {
                using (Stream stream1 = File.Open(dossier + "\\Date.bin", FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    userData = (TimeSpan)binaryFormatter.Deserialize(stream1);
                }
            }
            catch
            {
                using (Stream stream = File.Open(dossier + "\\Date.bin", FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, userData);
                }
            }
            return userData;
        }
    }
}
