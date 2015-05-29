using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public abstract class Reserve
    {
        public virtual string StartDate
        {
            get;
            set;
        }

        public virtual string EndDate
        {
            get;
            set;
        }

        public virtual Category Category
        {
            get;
            set;
        }

        public virtual Account Account
        {
            get;
            set;
        }

        public virtual bool Paid
        {
            get;
            set;
        }

        public int ReserveringsID { get; set; }

        public Reserve(Account Account, Category Category, string EndDate, string StartDate, bool Paid, int ReserveringsID)
        {
            this.Account = Account;
            this.Category = Category;
            this.EndDate = EndDate;
            this.StartDate = StartDate;

            this.ReserveringsID = ReserveringsID;
        }
    }
}