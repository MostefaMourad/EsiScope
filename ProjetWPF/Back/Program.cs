using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjetWPF
{
    class Programml
    {
        private void Mainm()
        {
            DayData jour = new DayData();
            jour.DateDuJour = new DateTime(2019,2,5);
            jour.TempuratureMax = 14;
            jour.TempuratureMin=9;
            jour.Humidite=65;
            jour.Pression=769.5f;
            jour.Precipitation=0;
            jour.Nebulosite=10;
            jour.VitesseDuVent=2;
            jour.DirectionDuVent[0]=(Direction.SUD);
            jour.DirectionDuVent[0] = (Direction.SUD_EST);
            jour.DistanceDeVisibilite = 10;


            DataWilayaPrediction DonnesMeteo = IOData.LireDonnesWilayaPrediction(@"C:\Users\moham\Desktop\Projet2cp\PRE", 16, 5);
            DonnesMeteo.CalculerPreduction(jour);  




















            /*
            //Convertir les fichier exel qui se trouve dans le dossier DT3 . en fichier binaire dans DATABINAIRE (le fichier excel dois etre nommée ex: 1.csv)
            Conversion.Convertir(@"C:\Users\moham\Desktop\Projet2cp\DT3", @"C:\Users\moham\Desktop\Projet2cp\DATABINAIRE");
            Console.WriteLine("Fin de convertir \n\n\nPress Any key");
            Console.Read();
            //Affichier lecontenue du fichier binaire ...\48.bin 
            Conversion.AffichierBinaire(@"C:\Users\moham\Desktop\Projet2cp\DATABINAIRE",48);
            Console.WriteLine("Fin de l'affichage du fichier binaire ...\\48.bin\nPress Any key");
            Console.ReadLine();
            //Creation de 48 fichier de preduction apartir des fichier binaire qui se trouve dans le dossier (...\DATABINAIRE)
            for (int i = 1; i <= 48; i++)
            {
                //Creation
                Conversion.FichierPrediction(@"C:\Users\moham\Desktop\Projet2cp\DATABINAIRE", @"C:\Users\moham\Desktop\Projet2cp\PRE", i, 5);
                //Récupirer  le contenu du des fichiers de preduction dans (DonnesMeteo)
                DataWilayaPrediction DonnesMeteo = IOData.LireDonnesWilayaPrediction(@"C:\Users\moham\Desktop\Projet2cp\PRE", i, 5);
                DonnesMeteo.Afficher();
            }*/

            //Console.ReadLine();
            
        }
    }
}