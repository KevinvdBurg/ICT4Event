// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBEvent.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The db event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Data.OracleClient;

    /// <summary>
    /// The db event.
    /// </summary>
    public class DBEvent : Database
    {
        /// <summary>
        /// Voegt het gegeven event toe aan de database
        /// </summary>
        /// <param name="Event">
        /// Event.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Insert(Event Event)
        {
            var administration = new Administration();
            var resultaat = false;
            var sql =
                "INSERT INTO EVENT (\"ID\",\"naam\", \"maxBezoekers\", \"datumstart\", \"datumEinde\", \"locatie_id\") VALUES (:id, :naam, :maxbezoekers, :datumstart, :datumeinde, :locatie_id)";
            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("id", Convert.ToInt32(Event.EventID)));
                cmd.Parameters.Add(new OracleParameter("naam", Event.Name));
                cmd.Parameters.Add(new OracleParameter("maxbezoekers", Convert.ToInt32(Event.MaxPerson)));
                cmd.Parameters.Add(new OracleParameter("datumstart", Event.BeginTime));
                cmd.Parameters.Add(new OracleParameter("datumEinde", Event.EndTime));
                cmd.Parameters.Add(
                    new OracleParameter(
                        "locatie_id", 
                        Convert.ToInt32(
                            administration.FindAddressID(Event.Location.Address.ZipCode, Event.Location.Address.Number))));
                cmd.ExecuteNonQuery();

                // OracleDataReader reader = cmd.ExecuteReader();
                resultaat = true;
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }

        /// <summary>
        /// Returned the selected Event by name
        ///     retouneert het geselecteerde event op naam
        /// </summary>
        /// <param name="EventName">
        /// Event.
        /// </param>
        /// <returns>
        /// The <see cref="Event"/>.
        /// </returns>
        public virtual Event Select(string EventName)
        {
            Event resultaat = null;

            var sql =
                "Select e.\"ID\", e.\"naam\", e.\"maxBezoekers\", e.\"datumstart\", e.\"datumEinde\", l.\"ID\", l.\"naam\" as naam_1, l.\"nr\", l.\"plaats\", l.\"postcode\", l.\"straat\" From Event e Inner Join Locatie l On e.\"locatie_id\" = l.\"ID\" Where e.\"naam\" = :name";

            var eventid = 0;
            var name = string.Empty;
            var maxpers = 0;
            var begindate = string.Empty;
            var enddate = string.Empty;
            var nr = string.Empty;
            var place = string.Empty;
            var zipcode = string.Empty;
            var country = string.Empty;
            var locationname = string.Empty;
            var straat = string.Empty;

            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("name", EventName));
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eventid = Convert.ToInt32(reader["ID"]);
                        name = Convert.ToString(reader["naam"]);
                        locationname = Convert.ToString(reader["naam_1"]);
                        maxpers = Convert.ToInt32(reader["maxBezoekers"]);
                        begindate = Convert.ToString(reader["datumstart"]);
                        enddate = Convert.ToString(reader["datumEinde"]);
                        nr = Convert.ToString(reader["nr"]);
                        place = Convert.ToString(reader["plaats"]);
                        zipcode = Convert.ToString(reader["postcode"]);
                        straat = Convert.ToString(reader["straat"]);
                    }

                    resultaat = new Event(
                        new Location(new Address(place, nr, zipcode, straat), locationname), 
                        maxpers, 
                        name, 
                        eventid, 
                        begindate, 
                        enddate);
                }
            }
            catch (OracleException e)
            {
                throw;
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }

        /// <summary>
        /// Doorzoekt de database naar een event met een passend id
        /// </summary>
        /// <param name="EventID">
        /// Event.
        /// </param>
        /// <returns>
        /// The <see cref="Event"/>.
        /// </returns>
        public Event Select(int EventID)
        {
            Event resultaat = null;

            var sql =
                "Select \"e.ID\", \"e.naam\", \"e.maxBezoekers\", \"e.datumstart\", \"e.datumEinde\", \"l.ID\", \"l.nr\", \"l.plaats\", \"l.postcode\", \"l.straat\" From Event e Inner Join Locatie l On \"e.ID\" = \"l.ID\" Where \"e.ID\" = :EventID";

            var eventid = 0;
            var name = string.Empty;
            var maxpers = 0;
            var begindate = string.Empty;
            var enddate = string.Empty;
            var nr = string.Empty;
            var place = string.Empty;
            var zipcode = string.Empty;
            var country = string.Empty;
            var straat = string.Empty;

            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("EventID", EventID));
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eventid = Convert.ToInt32(reader["EVENTID"]);
                        name = Convert.ToString(reader["Naam"]);
                        maxpers = Convert.ToInt32(reader["MAXPERSONEN"]);
                        begindate = Convert.ToString(reader["BEGINDATUM"]);
                        enddate = Convert.ToString(reader["EINDDATUM"]);
                        nr = Convert.ToString(reader["HUISNUMMER"]);
                        place = Convert.ToString(reader["PLAATS"]);
                        zipcode = Convert.ToString(reader["POSTCODE"]);
                        straat = Convert.ToString(reader["straat"]);
                    }

                    resultaat = new Event(
                        new Location(new Address(place, nr, zipcode, straat), name), 
                        maxpers, 
                        name, 
                        eventid, 
                        begindate, 
                        enddate);
                }
            }
            catch (OracleException e)
            {
                throw;
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }

        /// <summary>
        /// retouneerd een lijst van alle events uit de database
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Event> SelectAll()
        {
            var resultaat = new List<Event>();
            Event AddedEvent = null;
            var sql =
                "Select e.\"ID\", e.\"naam\", e.\"maxBezoekers\", e.\"datumstart\", e.\"datumEinde\", l.\"ID\", l.\"nr\", l.\"plaats\", l.\"postcode\", l.\"straat\" From Event e Inner Join Locatie l On e.\"locatie_id\" = l.\"ID\"";

            var eventid = 0;
            var name = string.Empty;
            var maxpers = 0;
            var begindate = string.Empty;
            var enddate = string.Empty;
            var nr = string.Empty;
            var place = string.Empty;
            var zipcode = string.Empty;
            var country = string.Empty;
            var straat = string.Empty;

            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eventid = Convert.ToInt32(reader["ID"]);
                        name = Convert.ToString(reader["naam"]);
                        maxpers = Convert.ToInt32(reader["maxBezoekers"]);
                        begindate = Convert.ToString(reader["datumstart"]);
                        enddate = Convert.ToString(reader["datumEinde"]);
                        nr = Convert.ToString(reader["nr"]);
                        place = Convert.ToString(reader["plaats"]);
                        zipcode = Convert.ToString(reader["postcode"]);
                        straat = Convert.ToString(reader["straat"]);
                        AddedEvent = new Event(
                            new Location(new Address(place, nr, zipcode, straat), name), 
                            maxpers, 
                            name, 
                            eventid, 
                            begindate, 
                            enddate);
                        resultaat.Add(AddedEvent);
                    }

                    return resultaat;
                }
            }
            catch (OracleException e)
            {
                throw;
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }

        /// <summary>
        /// Update Event in de database
        /// </summary>
        /// <param name="Event">
        /// Event.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool UpdateEvent(Event Event)
        {
            var administration = new Administration();
            var resultaat = false;
            string sql;
            string sql2;
            sql =
                "UPDATE EVENT SET \"naam\" = :name, \"maxBezoekers\" = :maxbezoeker, \"datumstart\"= :datumstart, \"datumEinde\" = :datumeinde WHERE \"ID\" = :EventID";

            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("name", Event.Name));
                cmd.Parameters.Add(new OracleParameter("maxbezoeker", Event.MaxPerson));
                cmd.Parameters.Add(new OracleParameter("EventID", Event.EventID));
                cmd.Parameters.Add(new OracleParameter("datumstart", Event.BeginTime));
                cmd.Parameters.Add(new OracleParameter("datumeinde", Event.EndTime));
                cmd.ExecuteNonQuery();
                resultaat = true;
            }
            catch (OracleException e)
            {
                throw;
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }
    }
}