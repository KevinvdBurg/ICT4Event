using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;
    using System.Net.Sockets;
    using System.Text.RegularExpressions;

    public class DBReserve : Database
    {
        public List<CampingSpot> FindCampingSpots()
        {
            List<CampingSpot> result = new List<CampingSpot>();
            //string sql = "SELECT * FROM plek WHERE id NOT IN (SELECT plek_id FROM plek_reservering)";
            string sql = "SELECT * FROM plek";
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["id"]);
                        int LocationID = Convert.ToInt32(reader["locatie_id"]);
                        string Number = Convert.ToString(reader["nummer"]);
                        int Capticity = Convert.ToInt32(reader["capaciteit"]);

                        CampingSpot campingSpot = new CampingSpot(ID, LocationID, Number, Capticity);
                        result.Add(campingSpot);
                    }
                }
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                DisConnect();
            }
            return result;
        }

        public bool FindFreeSpots(int ID)
        {
            string sql = "SELECT  \"plek_id\" FROM plek_reservering WHERE \"plek_id\" = :nummer";
            bool result = false;
            int number;
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add((new OracleParameter("nummer", ID)));
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        number = Convert.ToInt32(reader["plek_id"]);
                        if (number == ID)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                DisConnect();
            }
            return result;
        }

        
        //Zoekt de laatste reservering
        //public int HighestID()
        //{
        //    int result = 0;
        //    string sql = "SELECT MAX(reserveringid) As highest FROM kampeerplekreservering";
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
        ////Zoek het laatst gehuurde item
        //public int HighestReserveItemID()
        //{
        //    int result = 0;
        //    string sql = "SELECT MAX(verhuurid) As highest FROM verhuur";
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

        ////voegt een item toe aan een event
        //public bool Insert(ReserveItem reserveItem, int CurrentEventID)
        //{
        //    Administration administration = new Administration();
        //    int paid = 0;
        //    int accountID = administration.FindAccountID(reserveItem.Account.Person.Email);
        //    int itemID = administration.FindItemID(reserveItem.Item.Name);
        //    bool resultaat = false;
        //    if (reserveItem.Paid)
        //    {
        //        paid = 1;
        //    }
        //    string sql =
        //        "INSERT  INTO verhuur (VERHUURID, GEBRUIKERID, ITEMID, DATUMIN, DATUMUIT) VALUES (:verhuurid, :gebruikerid, :itemid, :datumin, :datumuit)";
        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("verhuurid", reserveItem.ReserveringsID));
        //        cmd.Parameters.Add(new OracleParameter("gebruikerid", accountID));
        //        cmd.Parameters.Add(new OracleParameter("itemid", itemID));
        //        cmd.Parameters.Add(new OracleParameter("datumin", reserveItem.StartDate));
        //        cmd.Parameters.Add(new OracleParameter("datumuit", reserveItem.EndDate));
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

        ////voegt plekken toe aan een event
        //public bool Insert(ReserveSpot reservespot, int CurrentEventID)
        //{
        //    Administration administration = new Administration();
        //    int paid = 0;
        //    int accountID = administration.FindAccountID(reservespot.Account.Person.Email);
        //    bool resultaat = false;
        //    if (reservespot.Paid)
        //    {
        //        paid = 1;
        //    }
        //    string sql;
        //    string sql2;
        //    string sql3;
        //    sql = "INSERT INTO KAMPEERPLEKRESERVERING (RESERVERINGID, GEBRUIKERID, KAMPEERPLEKID, BETAALD, DATUMIN, DATUMUIT) VALUES (:reserveringid, :gebruikerid, :kampeerplekid, :betaald, :datumin, :datumuit)";
        //    sql2 = "INSERT INTO GEBRUIKERKAMPEERRES (GEBRUIKERID, RESERVERINGID ) VALUES (:gebruikerid, :reserveringid)";
        //    sql3 = "INSERT INTO GEBRUIKEREVENT (GEBRUIKERID, EVENTID, AANWEZIG) VALUES (:gebruikerid, :currentevent, '0')";
        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("reserveringid", reservespot.ReserveringsID));
        //        cmd.Parameters.Add(new OracleParameter("gebruikerid", accountID));
        //        cmd.Parameters.Add(new OracleParameter("kampeerplekid", reservespot.CampingSpot.SpotID));
        //        cmd.Parameters.Add(new OracleParameter("betaald", paid));
        //        cmd.Parameters.Add(new OracleParameter("datumin", reservespot.StartDate));
        //        cmd.Parameters.Add(new OracleParameter("datumuit", reservespot.EndDate));
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


        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql2, connection);
        //        cmd.Parameters.Add(new OracleParameter("gebruikerid", accountID));
        //        cmd.Parameters.Add(new OracleParameter("reserveringid", reservespot.ReserveringsID));
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

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql3, connection);
        //        cmd.Parameters.Add(new OracleParameter("gebruikerid", accountID));
        //        cmd.Parameters.Add(new OracleParameter("currentevent", CurrentEventID));
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

        ////haalt een reservering op
        //internal Reserve Select(int reserveringID, Account account)
        //{
        //    ReserveSpot resultaat = null;
        //    string sql =
        //        "Select gb.RFID, kr.reserveringID, kp.KAMPEERPLEKID, kp.LOCATIEID, kr.BETAALD, kr.DATUMIN, kr.DATUMUIT, kc.DETAILS, kc.MAXPERSONEN, kc.PRIJS,g.GROEPID, g.GROEPNAAM From Kampeerplekreservering kr Inner Join Kampeerplek kp ON kr.KAMPEERPLEKID = kp.KAMPEERPLEKID Inner join KAMPEERPLEKCATEGORIE kc On kc.KAMPEERPLEKCATEGORIEID = kp.CATEGORIEID Inner Join GROEPSRESERVERING gr On gr.RESERVERINGID = kr.RESERVERINGID Inner Join Groep g On g.GROEPID = gr.GROEPID Inner Join GEBRUIKERKAMPEERRES gkr On gkr.GEBRUIKERID = kr.GEBRUIKERID Inner Join Gebruiker gb On gb.GEBRUIKERID = gkr.GEBRUIKERID where kr.reserveringID = :reserveringID";

        //    string RFID = "";
        //    int KAMPEERPLEKID = 0;
        //    bool BETAALD = false;
        //    string DATUMIN = "";
        //    string DATUMUIT = "";
        //    int MAXPERSONEN = 0;
        //    decimal PRIJS = 0;
        //    int GROEPID = 0;
        //    string GROEPNAAM = "";
        //    string DETAILS = "";
        //    int locatieID = 0;

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("reserveringID", reserveringID));
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                RFID = Convert.ToString(reader["RFID"]);
        //                KAMPEERPLEKID = Convert.ToInt32(reader["KAMPEERPLEKID"]);
        //                locatieID = Convert.ToInt32(reader["LOCATIEID"]);
        //                BETAALD = Convert.ToBoolean(reader["BETAALD"]);
        //                DATUMIN = Convert.ToString(reader["MAXPERSONEN"]);
        //                DATUMUIT = Convert.ToString(reader["MAXPERSONEN"]);
        //                MAXPERSONEN = Convert.ToInt16(reader["EINDDATUM"]);
        //                PRIJS = Convert.ToDecimal(reader["MAXPERSONEN"]);
        //                GROEPID = Convert.ToInt32(reader["GROEPID"]);
        //                GROEPNAAM = Convert.ToString(reader["GROEPNAAM"]);
        //                DETAILS = Convert.ToString(reader["DETAILS"]);
        //            }
        //            resultaat =
        //                new ReserveSpot(
        //                    new CampingSpot(new CategorySpots(MAXPERSONEN, DETAILS, PRIJS), locatieID, KAMPEERPLEKID),
        //                    new Group(GROEPNAAM, GROEPID), account, new CategorySpots(MAXPERSONEN, DETAILS, PRIJS), DATUMUIT,
        //                    DATUMIN, BETAALD, reserveringID);
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


        //// kijkt of een reservering betaald is
        //internal List<string> Check(int reserveringID)
        //{
        //    List<string> resultaat = new List<string>();
        //    string sql =
        //        "Select kpr.KAMPEERPLEKID, g.achternaam, g.emailadres, gp.GROEPNAAM, kpr.BETAALD From Kampeerplekreservering kpr Inner Join Gebruiker g ON g.gebruikerId = kpr.GEBRUIKERID FULL OUTER JOIN GROEPSRESERVERING gr ON gr.RESERVERINGID = kpr.RESERVERINGID FULL OUTER JOIN GROEP gp ON gp.groepid = gr.groepid WHERE kpr.RESERVERINGID = :reserveringID";

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("reserveringID", reserveringID));
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                string KAMPEERPLEKID = Convert.ToString(reader["KAMPEERPLEKID"]);
        //                string ACHTERNAAM = Convert.ToString(reader["achternaam"]);
        //                string emailadres = Convert.ToString(reader["emailadres"]);
        //                string GROEPNAAM = Convert.ToString(reader["GROEPNAAM"]);
        //                string BETAALD = Convert.ToString(reader["BETAALD"]);
        //                resultaat.Add(KAMPEERPLEKID);
        //                resultaat.Add(ACHTERNAAM);
        //                resultaat.Add(emailadres);
        //                resultaat.Add(GROEPNAAM);
        //                resultaat.Add(BETAALD);
        //            }
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


        ////zorgt ervoor dat een reservering betaald is
        //internal bool UpdatePayment(int reserveringID)
        //{
        //    string updateID = "'" + reserveringID + "'";
        //    bool resultaat = false;
        //    string sql = "UPDATE KAMPEERPLEKRESERVERING SET BETAALD = '1' WHERE RESERVERINGID = " + updateID;
        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        //cmd.Parameters.Add(new OracleParameter("reserveringID", reserveringID));
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
        ////haalt alle reserveringen op
        //public List<ReserveItem> SelectAllItems()
        //{
        //    List<ReserveItem> resultaat = new List<ReserveItem>();
        //    string sql =
        //        "Select gb.EMAILADRES, gb.VOORNAAM, gb.ACHTERNAAM, gb.HUISNUMMER, gb.POSTCODE, gb.HUISNUMMER, gb.ISADMIN, gb.PLAATS, gb.WACHTWOORD, gb.RFID, v.DATUMIN, v.DATUMUIT, I.DETAILS, I.MERK, I.NAAM, I.PRIJS, v.VERHUURID, ic.naam as Itemcate  from verhuur v Inner Join Gebruiker gb On gb.GEBRUIKERID = v.GEBRUIKERID Inner Join Item I On i.ItemID = v.Itemid Inner Join Itemcategorie IC ON IC.ItemcategorieID = I.ITEMCATEGORIEID";

        //    string TYPE = "";
        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {

        //                string BRAND = Convert.ToString(reader["MERK"]);

        //                bool PRESSENT = true;
        //                string CITY = Convert.ToString(reader["PLAATS"]);
        //                string EMAIL = Convert.ToString(reader["EMAILADRES"]);
        //                string NAME = Convert.ToString(reader["VOORNAAM"]);
        //                string LASTNAME = Convert.ToString(reader["ACHTERNAAM"]);
        //                string ITEMNAAM = Convert.ToString(reader["NAAM"]);

        //                string ZIPCODE = Convert.ToString(reader["POSTCODE"]);
        //                string NUMBER = Convert.ToString(reader["HUISNUMMER"]);
        //                string RFIDd = Convert.ToString(reader["RFID"]);
        //                string WACHTWOORD = Convert.ToString(reader["WACHTWOORD"]);
        //                string DETAILS = Convert.ToString(reader["DETAILS"]);
        //                Decimal PRICE = Convert.ToDecimal(reader["PRIJS"]);
        //                string EndDate = Convert.ToString(reader["DATUMUIT"]);
        //                string STARTDATE = Convert.ToString(reader["DATUMIN"]);
        //                bool Paid = true;
        //                int ReserveringsID = Convert.ToInt32(reader["VERHUURID"]);
        //                string icnaam = Convert.ToString(reader["Itemcate"]);
        //                bool boolbetaald = false;

        //                if (Convert.ToInt32(reader["isAdmin"]) > 0)
        //                {
        //                    TYPE = "admin";
        //                }
        //                else
        //                {
        //                    TYPE = "bezoeker";
        //                }
        //                Item item = new Item(new CategoryItems(icnaam, DETAILS, PRICE), BRAND, ITEMNAAM);
        //                ReserveItem tempResev = new ReserveItem(
        //                    item,
        //                    PRESSENT,
        //                    new Account(
        //                        new Person(
        //                            new Address(CITY, NUMBER, ZIPCODE),
        //                            EMAIL, NAME, LASTNAME),
        //                        TYPE, RFIDd, WACHTWOORD),
        //                    new Category(DETAILS, PRICE),
        //                    EndDate, STARTDATE, Paid, ReserveringsID);

        //                resultaat.Add(tempResev);

        //            }
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

    }
}