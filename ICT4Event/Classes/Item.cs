using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Item
    {
        public Item(int exemplaarId, string merk, string serie, int typeNummer, int prijs)
        {
            this.ExemplaarID = exemplaarId;
            this.Merk = merk;
            this.Serie = serie;
            this.TypeNummer = typeNummer;
            this.Prijs = prijs;
        }

        public int ExemplaarID { get; set; }

        public string Merk { get; set; }

        public string Serie { get; set; }

        public int TypeNummer { get; set; }

        public int Prijs { get; set; }


        public string ToString()
        {
            string output;
            output = "Exemplaar_ID: " + this.ExemplaarID + ". Merk: " + this.Merk + ". Serie: " + this.Serie
                                 + ". TypeNummer: " + this.TypeNummer + ". prijs: " + this.Prijs + ".";
            return output;
        }
    }
}