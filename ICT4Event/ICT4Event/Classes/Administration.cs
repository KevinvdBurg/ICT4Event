using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Windows.Forms;

    public class Administration
    {
        Database DB = new Database();

        private DBLogin dblogin = new DBLogin();
        private DBPost dbpost = new DBPost();
        private DBEvent dbevent = new DBEvent();
        private DBReserve dbreserve = new DBReserve();
        private DBAddress dbaddress = new DBAddress();
        private DBCampingspot dbCampingspot = new DBCampingspot();
        private DBItem dbItem = new DBItem();

        public Administration()
        {

        }

        public List<CampingSpot> FindAllFreeCampingSpots()
        {
            List<CampingSpot> foundSpots = this.dbreserve.FindCampingSpots();
            List<CampingSpot> freeSpots = new List<CampingSpot>();
            foreach (var campingSpot in foundSpots)
            {
                if (!this.dbreserve.FindFreeSpots(campingSpot.ID))
                {
                    freeSpots.Add(campingSpot);
                }
            }
            return freeSpots;
        }

    }
}