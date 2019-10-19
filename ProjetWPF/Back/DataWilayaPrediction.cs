using System;
using System.Collections.Generic;

namespace ProjetWPF
{
    [Serializable]
    class DataWilayaPrediction
    {
        public List<Tuple<DayData, DayData>> donnesMeteoListePrediction = new List<Tuple<DayData, DayData>>();
        
        /// <summary>Ajouter est une methode statique de la classe DataWilayaPrediction .
        /// <para>Ajouter les donée du couple (unJour1,unJour2) dans la liste des données</para>
        /// </summary>
        public void Ajouter(DayData jour1, DayData jour2)
        {
            donnesMeteoListePrediction.Add(new Tuple<DayData, DayData>((DayData)jour1.Clone(), (DayData)jour2.Clone())); ;
        }
        /// <summary>Afficher est une methode statique de la classe DataWilayaPrediction .
        /// <para>Afficher Toute les donées de DataWilayaPrediction</para>
        /// </summary>
        public void Afficher()
        {
            foreach (Tuple<DayData, DayData> l in donnesMeteoListePrediction)
            {
                Console.WriteLine(l.Item1.DateDuJour + "    " + l.Item2.DateDuJour);
            }
        }

        public List<Tuple<float, DayData>> CalculerPreduction(DayData jour)
        {
            List<Tuple<float, DayData>> laPreduction = new List<Tuple<float, DayData>>();
            float preJour = 0;
            int i; byte j = 0;
            DateTime date = new DateTime(2010, jour.DateDuJour.Month, jour.DateDuJour.Day);
            DateTime dateFin = new DateTime(2010, jour.DateDuJour.Month, jour.DateDuJour.Day);
            //Console.WriteLine("Date initial :    " + date + "    " + j);
            date = date.AddDays(-15);
            dateFin = dateFin.AddDays(15);
            //Console.WriteLine("Date initial :    " + date + "    " + j);
            while (dateFin.Year != jour.DateDuJour.Year)
            {
                do
                {
                    i = donnesMeteoListePrediction.FindIndex(a => a.Item1.DateDuJour == date);

                    date = date.AddDays(1);
                    //Console.WriteLine("Date initial :    "+date+"    "+j);
                    j++;
                } while (i < 0 && date != dateFin.AddDays(1));
                if (i >= 0)
                {
                    while (i < donnesMeteoListePrediction.Count && donnesMeteoListePrediction[i].Item1.DateDuJour <= dateFin)
                    {
                        //Console.WriteLine(donnesMeteoListePrediction[i].Item1.DateDuJour + "  " + Simularite(jour, donnesMeteoListePrediction[i].Item1));
                        preJour = 100 - 25 * (float)Simularite(jour, donnesMeteoListePrediction[i].Item1);
                        if (preJour < 0) preJour = 0;
                        laPreduction.Add(new Tuple<float, DayData>(preJour, (DayData)(donnesMeteoListePrediction[i].Item2.Clone())));
                        /*if(simularite < seuil )
                         * Affichagedes donnees ^^
                         */
                        i++;
                    }
                }
                date = date.AddYears(1).AddDays(-j);
                dateFin = dateFin.AddYears(1);
                j = 0;
            }
            laPreduction.Sort((x, y) => y.Item1.CompareTo(x.Item1));
            foreach (Tuple<float, DayData> w in laPreduction)
            {
                Console.WriteLine(w.Item1 + "   " + w.Item2);
            }
            return laPreduction;
        }

        public float Simularite(DayData jour1, DayData jour2)
        {
            float resultat = 0f;
            if (!jour2.VideTempuratureMax() && !jour1.VideTempuratureMax()) resultat = resultat + 8 * ((float)Math.Abs(jour1.TempuratureMax - jour2.TempuratureMax)) / 40.0f;
            else resultat += 4f;
            if (!jour2.VideTempuratureMin() && !jour1.VideTempuratureMin()) resultat = resultat + 8 * ((float)Math.Abs(jour1.TempuratureMin - jour2.TempuratureMin)) / 40.0f;
            else resultat += 4f;
            if (!jour2.VidePression() && !jour1.VidePression()) resultat = resultat + 3 * Math.Abs(jour1.Pression - jour2.Pression) / 40.0f;
            else resultat += 1.5f;
            if (!jour2.VidePrecipitation()&& ! jour1.VidePrecipitation()) resultat = resultat + (0.5f) * ((float)Math.Abs(jour1.Precipitation - jour2.Precipitation)) / 100;
            else resultat += 0.25f;
            if (!jour2.VideNebulosite()&&!jour1.VideNebulosite()) resultat = resultat +(0.25f)* ((float)Math.Abs(jour1.Nebulosite - jour2.Nebulosite)) / 100;
            else resultat += 0.25f;
            if (!jour2.VideHumidite()&&!jour1.VideHumidite()) resultat = resultat + 3 * ((float)Math.Abs(jour1.Humidite - jour2.Humidite)) / 100;
            else resultat += 1.5f;
            if (!jour2.VideDistanceDeVisibilite()&&!jour1.VideDistanceDeVisibilite()) resultat = resultat + ((float)Math.Abs(jour1.DistanceDeVisibilite - jour2.DistanceDeVisibilite)) / 65;
            else resultat += 0.5f;
            //Direction du vent
            float resTmp = 0f;
            if (jour1.DirectionDuVent[0] == 0)
            {
                if (jour2.DirectionDuVent[0] == 0) resTmp = 0f;               
                else resTmp = 2f;
            }
            else
            {
                if (jour2.DirectionDuVent[0] == 0) resTmp = 2f;
                else
                {
                    resTmp = (Math.Abs(jour2.DirectionDuVent[0] - jour1.DirectionDuVent[0]));                    
                    if (resTmp > 4) resTmp = 8 - resTmp;
                }
            }
            resultat += resTmp / 4.0f;
            return resultat;
        }
    }
}
