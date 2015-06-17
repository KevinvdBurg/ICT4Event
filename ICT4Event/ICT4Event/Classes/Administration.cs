// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Administration.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The administration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// The administration.
    /// </summary>
    public class Administration
    {
        /// <summary>
        /// The dbaddress.
        /// </summary>
        private readonly DBAddress dbaddress = new DBAddress();

        /// <summary>
        /// The dbevent.
        /// </summary>
        private readonly DBEvent dbevent = new DBEvent();

        /// <summary>
        /// The db.
        /// </summary>
        private Database DB = new Database();

        /// <summary>
        /// Een event wordt doorgestuurd naar dbEvent zodat er een event toegevoegd kan worden aan de database
        /// </summary>
        /// <param name="Event">
        /// Event
        /// </param>
        public void AddEvent(Event Event)
        {
            this.dbevent.Insert(Event);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="Event">
        /// The event.
        /// </param>
        public void Delete(Event Event)
        {
            // TODO
        }

        /// <summary>
        /// Searched the database for all events for by event name
        /// </summary>
        /// <param name="EventName">
        /// Event.
        /// </param>
        /// <returns>
        /// The <see cref="Event"/>.
        /// </returns>
        public Event FindEvent(string EventName)
        {
            var foundEvent = this.dbevent.Select(EventName);

            if (foundEvent != null)
            {
                return foundEvent;
            }

            MessageBox.Show("Event niet gevonden");
            return null;
        }

        /// <summary>
        /// Doorzoekt alle events in de database naar een event met de passende eventid
        /// </summary>
        /// <param name="EventID">
        /// Event.
        /// </param>
        /// <returns>
        /// The <see cref="Event"/>.
        /// </returns>
        public Event FindEvent(int EventID)
        {
            var foundEvent = this.dbevent.Select(EventID);

            if (foundEvent != null)
            {
                return foundEvent;
            }

            MessageBox.Show("Event niet gevonden");
            return null;
        }

        /// <summary>
        /// Doorzoekt de database naar een adres met een passende postcode en huisnummer en retourneert vervolgens het adresid
        /// </summary>
        /// <param name="zipcode">
        /// Zipcode.
        /// </param>
        /// <param name="number">
        /// Number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int FindAddressID(string zipcode, string number)
        {
            var foundAddressID = this.dbaddress.FindAdressID(zipcode, number);

            if (foundAddressID != null)
            {
                return foundAddressID;
            }

            MessageBox.Show("AdresID niet gevonden");
            return Convert.ToInt32(null);
        }

        /// <summary>
        /// Retouneert alle Events in de database
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Event> FindEventAll()
        {
            var foundEvents = this.dbevent.SelectAll();

            if (foundEvents != null)
            {
                return foundEvents;
            }

            MessageBox.Show("Geen Events gevonden");
            return null;
        }

        /// <summary>
        /// update de gegevens van het event
        /// </summary>
        /// <param name="tempEvent">
        /// Tijdelijk Event.
        /// </param>
        public void UpdateEvent(Event tempEvent)
        {
            this.dbevent.UpdateEvent(tempEvent);
        }
    }
}