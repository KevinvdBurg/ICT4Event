using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;

    public class DBItem : Database
    {
        public List<Item> SelectAllItems()
        {
            List<CampingSpot> result = new List<CampingSpot>();
            //string sql = "SELECT * FROM plek WHERE id NOT IN (SELECT plek_id FROM plek_reservering)";
            string sql = "SELECT * FROM Productexemplaar";
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


            //public int ItemID (stringnaam)
            //{
            //    int itemID = -1;
            //    string sql = "SELECT itemid FROM item i WHERE naam = :naam";
            //    try
            //    {
            //        Connect();
            //        OracleCommand cmd = new OracleCommand(sql, connection);
            //        cmd.Parameters.Add(new OracleParameter("email", naam));
            //        OracleDataReader reader = cmd.ExecuteReader();
            //        if (reader.HasRows)
            //        {
            //            while (reader.Read())
            //            {
            //                itemID = Convert.ToInt32(reader["itemid"]);

            //            }
            //            return itemID;
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
            //    return itemID;

            //}
        }


    }
}