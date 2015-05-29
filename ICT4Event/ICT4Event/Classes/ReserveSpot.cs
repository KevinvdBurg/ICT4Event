using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class ReserveSpot : Reserve
    {
        public Group Group
        {
            get;
            set;
        }

        public CampingSpot CampingSpot
        {
            get;
            set;
        }

        public ReserveSpot(CampingSpot CampingSpot, Group Group, Account Account, Category Category, string EndDate, string StartDate, bool Paid, int ReserveringsID)
            : base(Account, Category, EndDate, StartDate, Paid, ReserveringsID)
        {
            this.CampingSpot = CampingSpot;
            this.Group = Group;
            this.Paid = Paid;
        }

        //public ReserveSpot(Account Account, Category Category, DateTime EndDate, DateTime StartDate, int RFID, bool Paid, Group @group, CampingSpot campingSpot) : base(Account, Category, EndDate, StartDate, RFID, Paid)
        //{
        //    Group = @group;
        //    CampingSpot = campingSpot;
        //}
    }
}