using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data;
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

        public List<string> FindInfo(int plekid)
        {
            List<string> resultaat = new List<string>();
            int locatie_id;
            string nummer;
            int capaciteit;
            string waarde;
            string naam;
            string output = "";
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand("VRIJEPLEKKEN", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.Add("P_ID", OracleType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add((new OracleParameter("P_ID", plekid)));

                OracleParameter returnParameter = cmd.Parameters.Add("C_Vrij", OracleType.Cursor);
                returnParameter.Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        locatie_id = Convert.ToInt32(reader["locatie_id"]);
                        nummer = Convert.ToString(reader["nummer"]);
                        capaciteit = Convert.ToInt32(reader["capaciteit"]);
                        waarde = Convert.ToString(reader["waarde"]);
                        naam = Convert.ToString(reader["naam"]);
                        output = "Locatie ID: " + locatie_id + ". Nummer: " + nummer + ". Capaciteit: " + capaciteit
                                 + ". waarde: " + waarde + ". Naam: " + naam + ".";
                        resultaat.Add(output);
                    }
                }

            }
            catch (OracleException
                e)
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
    }
}