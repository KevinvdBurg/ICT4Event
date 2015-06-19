// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Administration.cs" company="">
//   
// </copyright>
// <summary>
//   The administration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Windows.Forms;
    

    /// <summary>
    /// The administration.
    /// </summary>
    public class Administration
    {
        /// <summary>
        /// The db.
        /// </summary>
        Database DB = new Database();

        /// <summary>
        /// The dbreserve.
        /// </summary>
        private DBReserve dbreserve = new DBReserve();

        /// <summary>
        /// The db campingspot.
        /// </summary>
        private DBCampingspot dbCampingspot = new DBCampingspot();

        /// <summary>
        /// The db item.
        /// </summary>
        private DBItem dbItem = new DBItem();

        /// <summary>
        /// Initializes a new instance of the <see cref="Administration"/> class.
        /// </summary>
        public Administration()
        {

        }

        /// <summary>
        /// The find all free camping spots.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<CampingSpot> FindAllFreeCampingSpots()
        {
            List<CampingSpot> foundSpots = this.dbCampingspot.FindCampingSpots();
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

        /// <summary>
        /// The new person.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int NewPerson(Person person)
        {
            return this.dbreserve.NewPerson(person);
        }

        /// <summary>
        /// The new reservation.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <param name="plekid">
        /// The plekid.
        /// </param>
        public void NewReservation(Person person, string plekid)
        {
            this.dbreserve.NewReservation(person, plekid);
        }

        /// <summary>
        /// The get specifications list.
        /// </summary>
        /// <param name="plekid">
        /// The plekid.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> GetSpecificationsList(int plekid)
        {
            return this.dbCampingspot.FindInfo(plekid);
        }

        /// <summary>
        /// The get free items list.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Item> GetFreeItemsList()
        {
            return this.dbItem.FindFreeItemsList();
        }

        /// <summary>
        /// The new item reservation.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool NewItemReservation(Item item)
        {
            return this.dbItem.NewItemReservation(item);
        }
    }
}