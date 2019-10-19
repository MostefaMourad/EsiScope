using System;
using System.Collections.Generic;

namespace ProjetWPF
{
    class StatJour
    {
        //Acces au mois et année recherché 
        public int Mois;
        public int Annee;
        public int Wilaya;
        //Max et min sont des couples : Item1=Jour,Item2=Valeur>
        public Tuple<int, float> Max;
        public Tuple<int, float> Min;
        //Tableau represente les valeur x et y pour le tracé du diagramme
        public List<Tuple<int, float>> Tableau;
        //Constructeur de la classe
        public StatJour(int VM, int Wilaya, int Annee, int Mois)
        {
            int i;
            //Sauvegarde du mois et de l'annee
            this.Mois = Mois;
            this.Annee = Annee;
            this.Wilaya = Wilaya;
            //Initialisation de max et min
            Tuple<int, float> Max = new Tuple<int, float>(0, -1000), Min = new Tuple<int, float>(0, 1000);
            List<Tuple<int, float>> Tableau = new List<Tuple<int, float>>();
            DataWilaya Donnees = IOData.LireDonnesWilaya("../../Donnee", Wilaya);
            for (i = 0; i < Donnees.NombreDeJour(); i++)
            {
                if ((Donnees.GetElementAt(i).DateDuJour.Month == Mois) && (Donnees.GetElementAt(i).DateDuJour.Year == Annee))
                {
                    switch (VM)
                    {
                        case 1:
                            Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).TempuratureMin));
                            if (Donnees.GetElementAt(i).TempuratureMin <= Min.Item2) Min = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).TempuratureMin);
                            if (Donnees.GetElementAt(i).TempuratureMin > Max.Item2) Max = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).TempuratureMin);
                            break;
                        case 2:
                            Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).TempuratureMax));
                            if (Donnees.GetElementAt(i).TempuratureMax <= Min.Item2) Min = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).TempuratureMax);
                            if (Donnees.GetElementAt(i).TempuratureMax > Max.Item2) Max = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).TempuratureMax);
                            break;
                        case 3:
                            Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Humidite));
                            if (Donnees.GetElementAt(i).Humidite < Min.Item2) Min = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Humidite);
                            if (Donnees.GetElementAt(i).Humidite > Max.Item2) Max = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Humidite);
                            break;
                        case 4:
                            Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Pression));
                            if (Donnees.GetElementAt(i).Pression < Min.Item2) Min = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Pression);
                            if (Donnees.GetElementAt(i).Pression > Max.Item2) Max = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Pression);
                            break;
                        case 5:
                            Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Precipitation));
                            if (Donnees.GetElementAt(i).Precipitation < Min.Item2) Min = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Precipitation);
                            if (Donnees.GetElementAt(i).Precipitation > Max.Item2) Max = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Precipitation);
                            break;
                        case 6:
                            Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DistanceDeVisibilite));
                            if (Donnees.GetElementAt(i).DistanceDeVisibilite < Min.Item2) Min = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DistanceDeVisibilite);
                            if (Donnees.GetElementAt(i).DistanceDeVisibilite > Max.Item2) Max = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DistanceDeVisibilite);
                            break;
                        case 7:
                            Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).VitesseDuVent));
                            if (Donnees.GetElementAt(i).VitesseDuVent < Min.Item2) Min = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).VitesseDuVent);
                            if (Donnees.GetElementAt(i).VitesseDuVent > Max.Item2) Max = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).VitesseDuVent);
                            break;
                        case 8:
                            Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Nebulosite));
                            if (Donnees.GetElementAt(i).Nebulosite < Min.Item2) Min = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Nebulosite);
                            if (Donnees.GetElementAt(i).Nebulosite > Max.Item2) Max = new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).Nebulosite);
                            break;
                    }
                }
            }
            this.Tableau = Tableau;
            this.Max = Max;
            this.Min = Min;
        }
        public void Afficher()
        {
            foreach (Tuple<int, float> Couple in this.Tableau)
                Console.WriteLine("x=" + Couple.Item1 + "\\" + this.Mois + "\\" + this.Annee + " y=" + Couple.Item2);
            Console.WriteLine("Max du mois : " + this.Max.Item2 + " ,Atteint le : " + this.Max.Item1 + "\\" + this.Mois + "\\" + this.Annee);
            Console.WriteLine("Min du mois : " + this.Min.Item2 + " ,Atteint le : " + this.Min.Item1 + "\\" + this.Mois + "\\" + this.Annee);
        }
    }
    class StatMois
    {
        //Acces à la wilaya
        public int Wilaya;
        //Acces à l'année
        public int Annee;
        //Max et min sont des Triplets : Item1=Jour,Item2=Mois,Item3=Valeur
        public Tuple<int, int, float> Max;
        public Tuple<int, int, float> Min;
        public List<Tuple<int, float>> Tableau;
        public StatMois(int VM, int Wilaya, int Annee)
        {
            int i, jrs = 0;
            //Sauvegarde de la wilaya
            this.Wilaya = Wilaya;
            this.Annee = Annee;
            DataWilaya Donnees = IOData.LireDonnesWilaya("../../Donnee", Wilaya);
            //Initialisation de max et min
            Tuple<int, int, float> Max = new Tuple<int, int, float>(0, 0, -1000), Min = new Tuple<int, int, float>(0, 0, 1000);
            List<Tuple<int, float>> Tableau = new List<Tuple<int, float>>();
            float somme = 0;
            for (i = 0; i < Donnees.NombreDeJour(); i++)
            {
                if (Donnees.GetElementAt(i).DateDuJour.Year==this.Annee)
                {
                    switch (VM)
                    {
                        case 1:
                            if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideTempuratureMin())
                            {
                                somme += Donnees.GetElementAt(i).TempuratureMin;
                                jrs++;
                                if (Donnees.GetElementAt(i).TempuratureMin >= Max.Item3) Max = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).TempuratureMin);
                                if (Donnees.GetElementAt(i).TempuratureMin < Min.Item3) Min = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).TempuratureMin);
                            }
                            break;
                        case 2: // Temperature max
                            if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideTempuratureMax())
                            {
                                somme += Donnees.GetElementAt(i).TempuratureMax;
                                jrs++;
                                if (Donnees.GetElementAt(i).TempuratureMax >= Max.Item3) Max = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).TempuratureMax);
                                if (Donnees.GetElementAt(i).TempuratureMax < Min.Item3) Min = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).TempuratureMax);
                            }
                            break;
                        case 3:
                            if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideHumidite())
                            {
                                somme += Donnees.GetElementAt(i).Humidite;
                                jrs++;
                                if (Donnees.GetElementAt(i).Humidite > Max.Item3) Max = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).Humidite);
                                if (Donnees.GetElementAt(i).Humidite < Min.Item3) Min = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).Humidite);
                            }
                            break;
                        case 4:
                            if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VidePression())
                            {
                                somme += Donnees.GetElementAt(i).Pression;
                                jrs++;
                                if (Donnees.GetElementAt(i).Pression > Max.Item3) Max = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).Pression);
                                if (Donnees.GetElementAt(i).Pression < Min.Item3) Min = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).Pression);
                            }
                            break;
                        case 5:
                            if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VidePrecipitation())
                            {
                                somme += Donnees.GetElementAt(i).Humidite;
                                jrs++;
                                if (Donnees.GetElementAt(i).Precipitation > Max.Item3) Max = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).Precipitation);
                                if (Donnees.GetElementAt(i).Precipitation < Min.Item3) Min = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).Precipitation);
                            }
                            break;
                        case 6:
                            if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideDistanceDeVisibilite())
                            {
                                somme += Donnees.GetElementAt(i).DistanceDeVisibilite;
                                jrs++;
                                if (Donnees.GetElementAt(i).DistanceDeVisibilite > Max.Item3) Max = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DistanceDeVisibilite);
                                if (Donnees.GetElementAt(i).DistanceDeVisibilite < Min.Item3) Min = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DistanceDeVisibilite);
                            }
                            break;
                        case 7:
                            if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideVitesseDuVent())
                            {
                                somme += Donnees.GetElementAt(i).VitesseDuVent;
                                jrs++;
                                if (Donnees.GetElementAt(i).VitesseDuVent > Max.Item3) Max = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).VitesseDuVent);
                                if (Donnees.GetElementAt(i).VitesseDuVent < Min.Item3) Min = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).VitesseDuVent);
                            }
                            break;
                        case 8:
                            if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideNebulosite())
                            {
                                somme += Donnees.GetElementAt(i).Nebulosite;
                                jrs++;
                                if (Donnees.GetElementAt(i).Nebulosite > Max.Item3) Max = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).Nebulosite);
                                if (Donnees.GetElementAt(i).Nebulosite < Min.Item3) Min = new Tuple<int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).Nebulosite);
                            }
                            break;
                    }
                    // Ajout du Tuple si fin de l'année
                    if (i + 1 < Donnees.NombreDeJour())
                        if (jrs!=0&&Donnees.GetElementAt(i).DateDuJour.Month != Donnees.GetElementAt(i + 1).DateDuJour.Month)
                        {
                            Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Month, somme / jrs));
                            somme = 0;
                            jrs = 0;
                        }
                }
            }
            if (jrs != 0){ Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(Donnees.NombreDeJour()-1).DateDuJour.Month, somme / jrs));}
            this.Tableau = Tableau;
            this.Max = Max;
            this.Min = Min;
        }
        public void Afficher()
        {
            foreach (Tuple<int, float> Couple in this.Tableau)
                Console.WriteLine("x=" + Couple.Item1 + " y=" + Couple.Item2);
            Console.WriteLine("Max de l'annee " + this.Annee + " : " + this.Max.Item3 + " ,Atteint le : " + this.Max.Item1 + "\\" + this.Max.Item2 + "\\" + this.Annee);
            Console.WriteLine("Min de l'annee " + this.Annee + " : " + this.Min.Item3 + " ,Atteint le : " + this.Min.Item1 + "\\" + this.Min.Item2 + "\\" + this.Annee);
        }
    }
    class StatAnnee
    {
        //Acces à la wilaya
        public int Wilaya;
        //Max et min sont des Quadruplés : Item1=Jour,Item2=Mois,Item4=Année,Item3=Valeur
        public Tuple<int, int, int, float> Max;
        public Tuple<int, int, int, float> Min;
        public List<Tuple<int, float>> Tableau;
        public float moyenne=0;
        public DateTime startDate;
        public DateTime endDate;
        public StatAnnee(int VM,int Wilaya)
        {
            int i, jrs = 0,jrs2=0;
            //Sauvegarde de la wilaya
            this.Wilaya = Wilaya;
            DataWilaya Donnees = IOData.LireDonnesWilaya("../../Donnee",  Wilaya);
            if(Donnees!=null && Donnees.NombreDeJour() != 0)
            {
                startDate = Donnees.GetElementAt(0).DateDuJour;
                endDate = Donnees.GetElementAt(Donnees.NombreDeJour()-1).DateDuJour;
            }
            //Initialisation de max et min
            Tuple<int ,int, int, float> Max = new Tuple<int ,int, int, float>(0, 0, 0, -1000), Min = new Tuple<int ,int, int, float>(0, 0, 0, 1000);
            List<Tuple<int, float>> Tableau = new List<Tuple<int, float>>();
            float somme = 0;
            double sommeMoyenne = 0;
            for (i = 0; i < Donnees.NombreDeJour(); i++)
            {
                switch (VM)
                {
                    case 1:
                        if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideTempuratureMin())
                        {
                            somme += Donnees.GetElementAt(i).TempuratureMin;
                            jrs++;
                            if (Donnees.GetElementAt(i).TempuratureMin >= Max.Item4) Max = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).TempuratureMin);
                            if (Donnees.GetElementAt(i).TempuratureMin < Min.Item4) Min = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).TempuratureMin);
                        }
                        break;
                    case 2: // Temperature max
                        if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideTempuratureMax())
                        {
                            somme += Donnees.GetElementAt(i).TempuratureMax;
                            jrs++;
                            if (Donnees.GetElementAt(i).TempuratureMax >= Max.Item4) Max = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).TempuratureMax);
                            if (Donnees.GetElementAt(i).TempuratureMax < Min.Item4) Min = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).TempuratureMax);
                        }
                        break;
                    case 3:
                        if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideHumidite())
                        {
                            somme += Donnees.GetElementAt(i).Humidite;
                            jrs++;
                            if (Donnees.GetElementAt(i).Humidite > Max.Item4) Max = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).Humidite);
                            if (Donnees.GetElementAt(i).Humidite < Min.Item4) Min = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).Humidite);
                        }
                        break;
                    case 4:
                        if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VidePression())
                        {
                            somme += Donnees.GetElementAt(i).Pression;
                            jrs++;
                            if (Donnees.GetElementAt(i).Pression > Max.Item4) Max = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).Pression);
                            if (Donnees.GetElementAt(i).Pression < Min.Item4) Min = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).Pression);
                        }
                        break;
                    case 5:
                        if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VidePrecipitation())
                        {
                            somme += Donnees.GetElementAt(i).Humidite;
                            jrs++;
                            if (Donnees.GetElementAt(i).Precipitation > Max.Item4) Max = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).Precipitation);
                            if (Donnees.GetElementAt(i).Precipitation < Min.Item4) Min = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).Precipitation);
                        }
                        break;
                    case 6:
                        if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideDistanceDeVisibilite())
                        {
                            somme += Donnees.GetElementAt(i).DistanceDeVisibilite;
                            jrs++;
                            if (Donnees.GetElementAt(i).DistanceDeVisibilite > Max.Item4) Max = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).DistanceDeVisibilite);
                            if (Donnees.GetElementAt(i).DistanceDeVisibilite < Min.Item4) Min = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).DistanceDeVisibilite);
                        }
                        break;
                    case 7:
                        if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideVitesseDuVent())
                        {
                            somme += Donnees.GetElementAt(i).VitesseDuVent;
                            jrs++;
                            if (Donnees.GetElementAt(i).VitesseDuVent > Max.Item4) Max = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).VitesseDuVent);
                            if (Donnees.GetElementAt(i).VitesseDuVent < Min.Item4) Min = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).VitesseDuVent);
                        }
                        break;
                    case 8:
                        if (Donnees.GetElementAt(i).Existe && !Donnees.GetElementAt(i).VideNebulosite())
                        {
                            somme += Donnees.GetElementAt(i).Nebulosite;
                            jrs++;
                            if (Donnees.GetElementAt(i).Nebulosite > Max.Item4) Max = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).Nebulosite);
                            if (Donnees.GetElementAt(i).Nebulosite < Min.Item4) Min = new Tuple<int, int, int, float>(Donnees.GetElementAt(i).DateDuJour.Day, Donnees.GetElementAt(i).DateDuJour.Month, Donnees.GetElementAt(i).DateDuJour.Year, Donnees.GetElementAt(i).Nebulosite);
                        }
                        break;
                }
                // Ajout du Tuple si fin de l'année
                if(i+1<Donnees.NombreDeJour())
                if (Donnees.GetElementAt(i).DateDuJour.Year!= Donnees.GetElementAt(i+1).DateDuJour.Year && jrs!=0)
                {
                    jrs2 += jrs;
                    sommeMoyenne += somme;
                    Tableau.Add(new Tuple<int, float>(Donnees.GetElementAt(i).DateDuJour.Year, somme / jrs));
                    somme = 0;
                    jrs = 0;
                }
            }

            if(jrs2!=0) moyenne= (float)(sommeMoyenne/jrs2);
            this.Tableau = Tableau;
            this.Max = Max;
            this.Min = Min;
        }
        public void Afficher()
        {
            foreach (Tuple<int, float> Couple in this.Tableau)
                Console.WriteLine("x=" + Couple.Item1 + " y=" + Couple.Item2);
            Console.WriteLine("Max de toutes les annees : " + this.Max.Item4 + " ,Atteint le : " + this.Max.Item1 + "\\" + this.Max.Item2+ "\\" + this.Max.Item3);
            Console.WriteLine("Min de toutes les annees : " + this.Min.Item4 + " ,Atteint le : " + this.Min.Item1 + "\\" + this.Min.Item2 + "\\" + this.Min.Item3);
        }
    }
    
}




