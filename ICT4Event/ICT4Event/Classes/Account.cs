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
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public bool Type { get; set; }
        public string Hash { get; set; }
        public bool Geactiveerd { get; set; }
        
        public Account(string gebruiksersnaam, string email, string wachtwoord, bool type, string hash, bool geactiveerd)
        {
            this.Gebruiksersnaam = gebruiksersnaam.ToLower();
            this.Email = email.ToLower();
            this.Wachtwoord = wachtwoord;  
            this.Type = type;
            this.Geactiveerd = geactiveerd;
            this.Hash = Convert.ToString(hash);     
        }

        public Account(string gebruiksersnaam, bool type)
        {
            this.Gebruiksersnaam = gebruiksersnaam;
            this.Type = type;
        }

        public Account(int gebruikersID, string gebruiksersnaam, string email)
        {
            this.GebruikerID = gebruikersID;
            this.Email = email;
            this.Gebruiksersnaam = gebruiksersnaam;
        }

        public Account()
        {
            
        }
    }
}