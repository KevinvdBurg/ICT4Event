using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;

    public class DBCampingspot : Database
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
    }
}