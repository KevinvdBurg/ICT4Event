using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Web.UI;
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
            List<CampingSpot> foundSpots = dbCampingspot.FindCampingSpots();
            List<CampingSpot> freeSpots = new List<CampingSpot>();
            foreach (var campingSpot in foundSpots)
            {
                if (!this.dbCampingspot.FindFreeSpots(campingSpot.ID))
                {
                    freeSpots.Add(campingSpot);
                }
            }
            return freeSpots;
        }

        /*public List<Item> FindAllFreeItems()
        {
            List<Item> foundItems = this.dbItem.SelectAllItems();
            List<Item> freeItems = new List<Item>();
            foreach (var foundItem in foundItems)
            {
                
            }
            return freeItems;
        }
        */

        public int NewPerson(Person person)
        {
            return this.dbreserve.NewPerson(person);
        }

        public void NewReservation(Person person, string plekid)
        {
            this.dbreserve.NewReservation(person, plekid);
        }

        public List<string> GetSpecificationsList(int plekid)
        {
            return this.dbCampingspot.FindInfo(plekid);
        }

        public List<Item> GetFreeItemsList()
        {
            return this.dbItem.FindFreeItemsList();
        }

        public bool NewItemReservation(Item item)
        {
            return this.dbItem.NewItemReservation(item);
        }
    }
}