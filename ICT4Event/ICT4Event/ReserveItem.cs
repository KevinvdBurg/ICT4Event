using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class ReserveItem : Reserve
    {
        public bool Present
        {
            get;
            set;
        }

        public Item Item
        {
            get;
            set;
        }

        public ReserveItem(Item Item, bool Present, Account Account, Category Category, string EndDate, string StartDate, bool Paid, int ReserveringsID)
            : base(Account, Category, EndDate, StartDate, Paid, ReserveringsID)
        {
            this.Item = Item;
            this.Present = Present;
        }

    }
}