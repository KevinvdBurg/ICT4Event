using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Account
    {
        public string Type
        {
            get;
            set;
        }

        public Person Person
        {
            get;
            set;
        }

        public string RFID
        {
            get;
            set;
        }

        public int GebruikerID { get; set; }
        public string Wachtwoord { get; set; }
        public Account(Person Person, string Type, string RFID, int GebruikerID)
        {
            this.Person = Person;
            this.Type = Type;
            this.RFID = RFID;
            this.GebruikerID = GebruikerID;
        }
        public Account(Person Person, string type, string RFID, string wachtwoord)
        {
            this.Person = Person;
            this.Type = type;
            this.RFID = RFID;
            this.Wachtwoord = wachtwoord;
        }

        public Account()
        {

        }
    }
}