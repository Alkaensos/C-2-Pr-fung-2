using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruefung2
{
    public class Model
    {
        public class Spieler
        {
            public object Id { get; set; }
            public string Nachname { get; set; }
            public string Vorname { get; set; }
            public string Strasse { get; set; }
            public string PLZ { get; set; }
            public string Ort { get; set; }
            public string Telefonnummer { get; set; }
            public double Hoehe { get; set; }
            public DateTime Geburtsdatum { get; set; }
            public int Nummer { get; set; }
            public string Position { get; set; }
            public int AnzahlSpiele { get; set; }
            public int AnzahlTore { get; set; }
            public int TeamID { get; set; }
        }
        public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Strasse { get; set; }
            public string PLZ { get; set; }
            public string Ort { get; set; }
            public string Telefonnummer { get; set; }
        }
    }
}
