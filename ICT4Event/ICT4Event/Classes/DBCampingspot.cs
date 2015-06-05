using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;

    public class DBCampingspot : Database
    {
        /// <summary>
        /// retourneert een lijst met alle kampeerplekken uit de database
        /// </summary>
        /// <returns></returns>
        //public List<CampingSpot> SelectAllSpots()
        //{
        //    List<CampingSpot> resultaat = new List<CampingSpot>();
        //    string sql =
        //        "select kpc.maxpersonen, kpc.prijs, kpc.details, kp.kampeerplekid, kp.locatieid from kampeerplekcategorie kpc, kampeerplek kp where kampeerplekcategorieid in (select categorieid from kampeerplek)";

        //    string details;
        //    int maxpersons;
        //    decimal price;
        //    int campingspotid;
        //    int locatieID;


        //    string type = "";
        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                maxpersons = Convert.ToInt32(reader["maxpersonen"]);
        //                price = Convert.ToDecimal(reader["prijs"]);
        //                details = Convert.ToString(reader["details"]);
        //                campingspotid = Convert.ToInt32(reader["kampeerplekid"]);
        //                locatieID = Convert.ToInt32(reader["locatieid"]);
        //                CampingSpot campingSpot = new CampingSpot(
        //                    new CategorySpots(maxpersons, details, price),
        //                    locatieID,
        //                    campingspotid);
        //                resultaat.Add(campingSpot);

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