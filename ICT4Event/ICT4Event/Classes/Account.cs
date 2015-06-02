using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Account

    {
        public int GebruikerID { get; set; }
        public string Gebruiksersnaam { get; set; }
        public string Hash { get; set; }
        public bool Type { get; set; }
        public bool Geactiveerd { get; set; }
        public string Wachtwoord { get; set; }

        public Account(string gebruiksersnaam, string hash, bool type, bool geactiveerd, string wachtwoord)
        {
            this.Gebruiksersnaam = gebruiksersnaam;
            this.Hash = hash;
            this.Type = type;
            this.Geactiveerd = geactiveerd;
            this.Wachtwoord = wachtwoord;    
        }

        public Account(string gebruiksersnaam, bool type)
        {
            this.Gebruiksersnaam = gebruiksersnaam;
            this.Type = type;
        }
        public Account()
        {

        }
    }
}