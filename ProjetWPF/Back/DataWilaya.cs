using System;
using System.Collections.Generic;

namespace ProjetWPF
{
    [Serializable]
    class DataWilaya
    {
        public List<DayData> listeDesJours=new List<DayData>();

        /// <summary>AjouterUnJour est une methode statique de la classe DataWilaya .
        /// <para>Ajouter les donée du jour "unJour" dans la liste des données</para>
        /// </summary>
        public void AjouterUnJour(DayData unJour) {
            listeDesJours.Add(unJour);
        }
        /// <summary>Afficher est une methode statique de la classe DataWilaya .
        /// <para>Afficher Toute les donées de DataWilaya</para>
        /// </summary>
        public void Afficher()
        {
            foreach (DayData l in listeDesJours) Console.WriteLine(l);
        }
        /// <summary>NombreDeJour est une methode statique de la classe DataWilaya .
        /// <para>Retourner le nombre de donées qui sont dans cet Objet </para>
        /// </summary>
        public int NombreDeJour()
        {
            return listeDesJours.Count;
        }
        /// <summary>GetElementAt est une methode statique de la classe DataWilaya .
        /// <para>Retourner l'elemnt numero i de la liste</para>
        /// </summary>
        public DayData GetElementAt(int i) {
            return listeDesJours[i];
        }
        /// <summary>ConstruireListePrediction est une methode statique de la classe DataWilaya .
        /// <para>Construire la liste a deux dimention qui contien les donées de prédiction</para>
        /// </summary>
        public DataWilayaPrediction ConstruireListePrediction(int Duree)
        {
            int j = 0;
            DayData DonneeLu1, DonneeLu2 = new DayData();
            DataWilayaPrediction DonnesMeteoListe2 = new DataWilayaPrediction();
            for (int i = 0; i <= listeDesJours.Count - 1; i++)
            {
                DonneeLu1 = listeDesJours[i];
                while (listeDesJours[j].DateDuJour.Date.CompareTo(listeDesJours[i].DateDuJour.Date.AddDays(Duree)) < 0) j++;
                if (listeDesJours[j].DateDuJour.Date.Equals(listeDesJours[i].DateDuJour.Date.AddDays(Duree)))
                {
                    DonneeLu2 = listeDesJours[j];
                    j++;
                    DonnesMeteoListe2.Ajouter(listeDesJours[i], DonneeLu2);
                }         
                if (j == listeDesJours.Count) break;
            }
            return DonnesMeteoListe2;
        }

        

        public bool RechercheParDate(DateTime date,out int index)
        {
            int parcourIndex=0;
            if (listeDesJours!=null && listeDesJours.Count > 0)
            {
                while (parcourIndex < listeDesJours.Count && listeDesJours[parcourIndex].DateDuJour < date.Date )  parcourIndex++;
                index = parcourIndex;
                if (parcourIndex < listeDesJours.Count) return listeDesJours[parcourIndex].DateDuJour.Date == date.Date;
                else return false;
            }
            else
            {
                index = -1;
                return false;
            }
        }
        
        public void ModifierUneDate(DayData donnée)
        {
            bool exist = RechercheParDate(donnée.DateDuJour, out int ind);
            if (exist)
            {
                listeDesJours[ind] = donnée;
            }
            else if(listeDesJours != null)
            {
                if (listeDesJours.Count > 0)
                {
                    if(listeDesJours.Count== ind) listeDesJours.Add(donnée);
                    else  listeDesJours.Insert(ind, donnée);
                }
                else listeDesJours.Add(donnée);
            }
        }

    }
}
