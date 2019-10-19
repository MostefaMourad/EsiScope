using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWPF
{
    [Serializable]
    public enum Direction
    {
        NON = 0,
        NORD = 1,
        NORD_EST = 2,
        EST = 3,
        SUD_EST = 4,
        SUD = 5,
        SUD_OUEST = 6,
        OUEST = 7,
        NORD_OUEST = 8,
    }
    [Serializable]
    public class DayData : ICloneable
    {
        public DateTime DateDuJour { get; set; }
        public sbyte TempuratureMin { get; set; }
        public sbyte TempuratureMax { get; set; }
        public float Pression{get; set;}
        public byte Humidite { get; set; }
        public byte VitesseDuVent{ get; set; }
        public float DistanceDeVisibilite{ get; set; }
        public float Precipitation { get; set; }
        public byte Nebulosite { get; set; }
        public Direction[] DirectionDuVent { get; set; }
        public bool Existe { get; set; }
        public bool Neige{ get; set; }


        public DayData()
        {
            DirectionDuVent = new Direction[2];
            TempuratureMin = 127;
            TempuratureMax = 127;
            Pression = 0;
            Humidite = 127;
            VitesseDuVent = 127;
            DistanceDeVisibilite = 127;
            Precipitation = 99999;
            Nebulosite = 127;
            DirectionDuVent[0] = Direction.NON;
            DirectionDuVent[1] = Direction.NON;
            Existe = false;
            Neige = false;
        }
        public bool VideTempuratureMin() => TempuratureMin == 127;
        public bool VideTempuratureMax() => TempuratureMax == 127;
        public bool VidePression() => Pression == 0;
        public bool VideHumidite() => Humidite == 127;
        public bool VideVitesseDuVent() => VitesseDuVent == 127;
        public bool VideDistanceDeVisibilite() => DistanceDeVisibilite == 127;
        public bool VidePrecipitation() => Precipitation == 99999;
        public bool VideNebulosite() => Nebulosite == 127;       
        public bool Vide() => Existe;
        public bool VideNeige() => !Neige;
        public override string ToString() => DateDuJour+ " TempuratureMin:  " + TempuratureMin + " TempuratureMax: " + TempuratureMax + " Nebulosite: "+ Nebulosite + " Pression: " + Pression + " Humidite: " + Humidite + " VitesseDuVent: " + VitesseDuVent + " DistanceDeVisibilite: " + DistanceDeVisibilite + " Precipitation: " + Precipitation + " " + DirectionDuVent[0] + " " + DirectionDuVent[1];

        //Pour faire une copie de l'objet 
        public object Clone() => MemberwiseClone();

    }
}