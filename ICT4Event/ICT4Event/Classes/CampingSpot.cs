// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampingSpot.cs" company="">
//   
// </copyright>
// <summary>
//   The camping spot.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The camping spot.
    /// </summary>

    public class CampingSpot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CampingSpot"/> class.
        /// </summary>
        /// <param name="ID">
        /// The id.
        /// </param>
        /// <param name="locationID">
        /// The location id.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <param name="maxPeople">
        /// The max people.
        /// </param>
        public CampingSpot(int ID, int locationID, string number, int maxPeople)
        {
            this.ID = ID;
            this.LocationID = locationID;
            this.Number = number;
            this.MaxPeople = maxPeople;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the location id.
        /// </summary>
        public int LocationID { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the max people.
        /// </summary>
        public int MaxPeople { get; set; }
    }
}