using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;

    public class DBEvent : Database
    {
        /// <summary>
        /// Voegt het gegeven event toe aan de database
        /// </summary>
        /// <param name="Event"></param>
        /// <returns></returns>
        //public bool Insert(Event Event)
        //{
        //    Administration administration = new Administration();
        //    bool resultaat = false;
        //    string sql = "INSERT INTO EVENT (EVENTID, NAAM, MAXPERSONEN, BEGINDATUM, EINDDATUM, LOCATIEID) VALUES (:eventid, :naam, :maxpersonen, :begindatum, :einddatum, :locatieid)";
        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("eventid", Event.EventID));
        //        cmd.Parameters.Add(new OracleParameter("naam", Event.Name));
        //        cmd.Parameters.Add(new OracleParameter("maxpersonen", Event.MaxPerson));
        //        cmd.Parameters.Add(new OracleParameter("begindatum", Event.BeginTime));
        //        cmd.Parameters.Add(new OracleParameter("einddatum", Event.EndTime));
        //        cmd.Parameters.Add(new OracleParameter("locatieid", administration.FindAddressID(Event.Location.Address.ZipCode, Event.Location.Address.Number)));
        //        cmd.ExecuteNonQuery();
        //        //OracleDataReader reader = cmd.ExecuteReader();
        //        resultaat = true;
        //    }
        //    catch (OracleException e)
        //    {

        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}

        //public int HighestID()
        //{
        //    int result = 0;
        //    string sql = "SELECT MAX(eventid) As highest FROM event";
        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                result = Convert.ToInt32(reader["highest"]);
        //            }
        //        }

        //    }
        //    catch (OracleException e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return result;
        //}
        ///// <summary>
        ///// Returned the selected Event by name
        ///// retouneert het geselecteerde event op naam
        ///// </summary>
        ///// <param name="EventName"></param>
        ///// <returns></returns>
        //public virtual Event Select(string EventName)
        //{
        //    Event resultaat = null;

        //    string sql = "Select e.EVENTID, e.Naam, e.MAXPERSONEN, e.BEGINDATUM, e.EINDDATUM, l.LOCATIEID, l.HUISNUMMER, l.PLAATS, l.POSTCODE From Event e Inner Join Locatie l On e.LOCATIEID = l.LOCATIEID Where e.Naam = :name";

        //    int eventid = 0;
        //    string name = "";
        //    int maxpers = 0;
        //    string begindate = "";
        //    string enddate = "";
        //    string nr = "";
        //    string place = "";
        //    string zipcode = "";
        //    string country = "";

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("Naam", name));
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                eventid = Convert.ToInt32(reader["EVENTID"]);
        //                name = Convert.ToString(reader["Naam"]);
        //                maxpers = Convert.ToInt32(reader["MAXPERSONEN"]);
        //                begindate = Convert.ToString(reader["BEGINDATUM"]);
        //                enddate = Convert.ToString(reader["EINDDATUM"]);
        //                nr = Convert.ToString(reader["HUISNUMMER"]);
        //                place = Convert.ToString(reader["PLAATS"]);
        //                zipcode = Convert.ToString(reader["POSTCODE"]);
        //            }
        //            resultaat = new Event(new Location(new Address(place, nr, zipcode), name), maxpers, name, eventid, begindate, enddate);
        //        }
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}

        ///// <summary>
        ///// Doorzoekt de database naar een event met een passend id
        ///// </summary>
        ///// <param name="EventID"></param>
        ///// <returns></returns>
        //public Event Select(int EventID)
        //{
        //    Event resultaat = null;

        //    string sql = "Select e.EVENTID, e.Naam, e.MAXPERSONEN, e.BEGINDATUM, e.EINDDATUM, l.LOCATIEID, l.HUISNUMMER, l.PLAATS, l.POSTCODE From Event e Inner Join Locatie l On e.LOCATIEID = l.LOCATIEID Where e.EventID = :EventID";

        //    int eventid = 0;
        //    string name = "";
        //    int maxpers = 0;
        //    string begindate = "";
        //    string enddate = "";
        //    string nr = "";
        //    string place = "";
        //    string zipcode = "";
        //    string country = "";

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("EventID", EventID));
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                eventid = Convert.ToInt32(reader["EVENTID"]);
        //                name = Convert.ToString(reader["Naam"]);
        //                maxpers = Convert.ToInt32(reader["MAXPERSONEN"]);
        //                begindate = Convert.ToString(reader["BEGINDATUM"]);
        //                enddate = Convert.ToString(reader["EINDDATUM"]);
        //                nr = Convert.ToString(reader["HUISNUMMER"]);
        //                place = Convert.ToString(reader["PLAATS"]);
        //                zipcode = Convert.ToString(reader["POSTCODE"]);
        //            }
        //            resultaat = new Event(new Location(new Address(place, nr, zipcode), name), maxpers, name, eventid, begindate, enddate);
        //        }
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}
        ///// <summary>
        ///// Returned all Events in a list
        ///// retouneert een lijst van events waar een account heen gaat
        ///// </summary>
        ///// <returns></returns>
        //public List<Event> SelectAllperAccount(Account account)
        //{
        //    Administration administration = new Administration();
        //    List<Event> resultaat = new List<Event>();
        //    Event AddedEvent = null;
        //    string sql = "Select e.EVENTID, e.Naam, e.MAXPERSONEN, e.BEGINDATUM, e.EINDDATUM, l.LOCATIEID, l.HUISNUMMER, l.PLAATS, l.POSTCODE From Event e Inner Join Locatie l On e.LOCATIEID = l.LOCATIEID Inner Join GebruikerEvent ge ON ge.EVENTID = e.EVENTID  where ge.GEBRUIKERID = :AccountID";

        //    int eventid = 0;
        //    string name = "";
        //    int maxpers = 0;
        //    string begindate = "";
        //    string enddate = "";
        //    string nr = "";
        //    string place = "";
        //    string zipcode = "";
        //    string country = "";

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        string accountID = Convert.ToString(administration.FindAccountID(account.Person.Email));
        //        cmd.Parameters.Add(new OracleParameter("AccountID", accountID));
        //        Console.WriteLine(cmd.CommandText);

        //        OracleDataReader reader = cmd.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                eventid = Convert.ToInt32(reader["EVENTID"]);
        //                name = Convert.ToString(reader["Naam"]);
        //                maxpers = Convert.ToInt32(reader["MAXPERSONEN"]);
        //                begindate = Convert.ToString(reader["BEGINDATUM"]);
        //                enddate = Convert.ToString(reader["EINDDATUM"]);
        //                nr = Convert.ToString(reader["HUISNUMMER"]);
        //                place = Convert.ToString(reader["PLAATS"]);
        //                zipcode = Convert.ToString(reader["POSTCODE"]);
        //                AddedEvent = new Event(new Location(new Address(place, nr, zipcode), name), maxpers, name, eventid, begindate, enddate);
        //                resultaat.Add(AddedEvent);
        //            }
        //            return resultaat;
        //        }
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}

        ///// <summary>
        ///// retouneerd een lijst van alle events uit de database
        ///// </summary>
        ///// <returns></returns>
        //public List<Event> SelectAll()
        //{
        //    List<Event> resultaat = new List<Event>();
        //    Event AddedEvent = null;
        //    string sql = "Select e.EVENTID, e.Naam, e.MAXPERSONEN, e.BEGINDATUM, e.EINDDATUM, l.LOCATIEID, l.HUISNUMMER, l.PLAATS, l.POSTCODE From Event e Inner Join Locatie l On e.LOCATIEID = l.LOCATIEID";

        //    int eventid = 0;
        //    string name = "";
        //    int maxpers = 0;
        //    string begindate = "";
        //    string enddate = "";
        //    string nr = "";
        //    string place = "";
        //    string zipcode = "";
        //    string country = "";

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                eventid = Convert.ToInt32(reader["EVENTID"]);
        //                name = Convert.ToString(reader["Naam"]);
        //                maxpers = Convert.ToInt32(reader["MAXPERSONEN"]);
        //                begindate = Convert.ToString(reader["BEGINDATUM"]);
        //                enddate = Convert.ToString(reader["EINDDATUM"]);
        //                nr = Convert.ToString(reader["HUISNUMMER"]);
        //                place = Convert.ToString(reader["PLAATS"]);
        //                zipcode = Convert.ToString(reader["POSTCODE"]);
        //                AddedEvent = new Event(new Location(new Address(place, nr, zipcode), name), maxpers, name, eventid, begindate, enddate);
        //                resultaat.Add(AddedEvent);
        //            }
        //            return resultaat;
        //        }
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}


        ///// <summary>
        ///// Retouneert een lijst met alle media uit de database met meer dan 5 reports
        ///// </summary>
        ///// <returns></returns>
        //public List<Media> SelectAllMedia()
        //{
        //    List<Media> resultaat = new List<Media>();
        //    string sql = "Select p.postID,p.AANTALREPORTS,bt.INHOUD, bd.BESTANDSLOCATIE FROM post p LEFT JOIN BESTAND bd ON p.POSTID = bd.POSTID LEFT JOIN BERICHT bt ON p.POSTID = bt.POSTID  WHERE AANTALREPORTS >= 5";

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                int postID = Convert.ToInt32(reader["postID"]);
        //                int AANTALREPORTS = Convert.ToInt32(reader["AANTALREPORTS"]);
        //                string INHOUD = Convert.ToString(reader["INHOUD"]);
        //                string BESTANDSLOCATIE = Convert.ToString(reader["BESTANDSLOCATIE"]);

        //                Media newMedia = new Media(postID, AANTALREPORTS, INHOUD, BESTANDSLOCATIE);
        //                resultaat.Add(newMedia);
        //            }
        //            return resultaat;
        //        }
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}

        ///// <summary>
        ///// Retouneert een lijst met alle aanwezige accounts
        ///// </summary>
        ///// <param name="EventID"></param>
        ///// <returns></returns>
        //public List<AccountEvent> SelectAllPresent(int EventID)
        //{
        //    List<AccountEvent> resultaat = new List<AccountEvent>();
        //    string sql = "Select g.GEBRUIKERID, g.Achternaam, kpr.KAMPEERPLEKID, kpr.DATUMIN, kpr.DATUMUIT From GebruikerEvent ge Inner Join Event e ON e.EventID = ge.eventID Inner join Gebruiker g ON g.GebruikerID = ge.GEBRUIKERID inner Join Kampeerplekreservering kpr ON kpr.GEBRUIKERID = g.GEBRUIKERID WHERE ge.aanwezig = 1 AND e.EVENTID = :eventID";
        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("eventID", EventID));
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                string Achternaam = Convert.ToString(reader["Achternaam"]);
        //                int KAMPEERPLEKID = Convert.ToInt32(reader["KAMPEERPLEKID"]);
        //                string DATUMIN = Convert.ToString(reader["DATUMIN"]);
        //                string DATUMUIT = Convert.ToString(reader["DATUMUIT"]);
        //                int GEBRUIKERID = Convert.ToInt32(reader["GEBRUIKERID"]);
        //                AccountEvent tempAccountEvent = new AccountEvent(true, GEBRUIKERID, EventID, KAMPEERPLEKID, DATUMIN, DATUMUIT, Achternaam);
        //                resultaat.Add(tempAccountEvent);
        //            }
        //            return resultaat;
        //        }
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}

        ///// <summary>
        ///// Retourneerd een bepaald media object uit de database waarbij postID gelijk is aan value
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public Media SelectMedia(string value)
        //{
        //    Media resultaat = null;
        //    string sql = "Select p.postID,p.AANTALREPORTS,bt.INHOUD, bd.BESTANDSLOCATIE, gb.achternaam FROM post p LEFT JOIN BESTAND bd ON p.POSTID = bd.POSTID LEFT JOIN BERICHT bt ON p.POSTID = bt.POSTID  inner join gebruiker gb ON p.GebruikerID = gb.GEBRUIKERID WHERE p.POSTID = :postID";
        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("postID", value));
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                int postID = Convert.ToInt32(reader["postID"]);
        //                int AANTALREPORTS = Convert.ToInt32(reader["AANTALREPORTS"]);
        //                string INHOUD = Convert.ToString(reader["INHOUD"]);
        //                string BESTANDSLOCATIE = Convert.ToString(reader["BESTANDSLOCATIE"]);
        //                string achternaam = Convert.ToString(reader["achternaam"]);

        //                Media newMedia = new Media(postID, AANTALREPORTS, INHOUD, BESTANDSLOCATIE, achternaam);
        //                resultaat = newMedia;
        //            }
        //            return resultaat;
        //        }
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}


        ///// <summary>
        ///// Verwijderd media uit de database
        ///// </summary>
        ///// <param name="media"></param>
        ///// <returns></returns>
        //public bool DeleteMedia(Media media)
        //{
        //    bool resultaat = false;
        //    string sql = "DELETE FROM Post WHERE PostID = :PostID";

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("PostID", media.PostID));
        //        //MessageBox.Show(cmd.ExecuteNonQueryAsync());
        //        cmd.ExecuteNonQuery();

        //        resultaat = true;
        //    }
        //    catch (OracleException e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}

        ///// <summary>
        ///// Update Event in de database
        ///// </summary>
        ///// <param name="Event"></param>
        ///// <param name="oldzip"></param>
        ///// <param name="oldhuisnummer"></param>
        ///// <returns></returns>
        //public bool UpdateEvent(Event Event, string oldzip, int oldhuisnummer)
        //{
        //    Administration administration = new Administration();
        //    int locationID = administration.FindAddressID(oldzip, Convert.ToString(oldhuisnummer));

        //    bool resultaat = false;
        //    string sql;
        //    string sql2;
        //    sql = "UPDATE EVENT SET NAAM = :name, MAXPERSONEN = :maxbezoeker WHERE EVENTID = :EventID";
        //    sql2 = "UPDATE LOCATIE SET PLAATS = :locationName, POSTCODE = :zipCode, HUISNUMMER = :huisnummer WHERE LocatieID = :LocatieID";


        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("name", Event.Name));
        //        cmd.Parameters.Add(new OracleParameter("maxbezoeker", Event.MaxPerson));
        //        cmd.Parameters.Add(new OracleParameter("EventID", Event.EventID));
        //        cmd.ExecuteNonQuery();
        //        resultaat = true;
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql2, connection);
        //        cmd.Parameters.Add(new OracleParameter("locationName", Event.Location.Name));
        //        cmd.Parameters.Add(new OracleParameter("zipCode", Event.Location.Address.ZipCode));
        //        cmd.Parameters.Add(new OracleParameter("huisnummer", Event.Location.Address.Number));
        //        cmd.Parameters.Add(new OracleParameter("LocatieID", locationID));
        //        cmd.ExecuteNonQuery();
        //        resultaat = true;
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }

        //    return resultaat;

        //}
    }
}