using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class AccountEvent
    {
        public bool Present { get; set; }
        public int AccountID { get; set; }
        public int EventID { get; set; }

        public int LocatieID { get; set; }

        public string DateIn { get; set; }
        public string DateOut { get; set; }

        public string LastName { get; set; }

        public AccountEvent(bool Present, int AccountID, int EventID)
        {
            this.Present = Present;
            this.AccountID = AccountID;
            this.EventID = EventID;
        }

        public AccountEvent(bool Present, int AccountID, int EventID, int LocatieID, string DateIn, string DateOut, string LastName)
        {
            this.Present = Present;
            this.AccountID = AccountID;
            this.EventID = EventID;
            this.LocatieID = LocatieID;
            this.DateIn = DateIn;
            this.DateOut = DateOut;
            this.LastName = LastName;

        }
    }
}