using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace ICT4Event.Classes
{
    public class DBIncheck : Database
    {
        public void InsertResPolsbandje(int reserveringid, string username, string barcode)
        {
            
            string sql;
            sql = "insert into reservering_polsbandje (\"reservering_id\",\"polsbandje_id\",\"account_id\", \"aanwezig\") values (:reserveringid, (select id from polsbandje where \"actief\" = 0 and \"barcode\" = :barcode), (select id from account where \"gebruikersnaam\" = :username), 1)";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                
                cmd.Parameters.Add(new OracleParameter("reserveringid", reserveringid));
                cmd.Parameters.Add(new OracleParameter("barcode", barcode));
                cmd.Parameters.Add(new OracleParameter("username", username));
                cmd.ExecuteNonQuery();
                
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }
        }

        public void SetPolsbandjeActive(string barcode)
        {

            string sql;
            sql = "update polsbandje set \"actief\" = 1 where \"barcode\" = :barcode";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);


                cmd.Parameters.Add(new OracleParameter("barcode", barcode));
                
                cmd.ExecuteNonQuery();

            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }
        }

        public int GetPaymentStatus(int resid)
        {
            int resultaat = 0;
            string sql;
            sql = "select \"betaald\" from reservering where id = :resid";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("resid", resid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32(reader["betaald"]);
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        public bool SetBetaald(int resid)
        {

            string sql;
            sql = "update reservering set \"betaald\" = 1 where id = :resid";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);


                cmd.Parameters.Add(new OracleParameter("resid", resid));

                cmd.ExecuteNonQuery();
                return true;

            }
            catch (OracleException e)
            {
                return false;
            }
            finally
            {
                this.Connection.Close();
                
            }
        }

        public void ResCheckOut(string barcode)
        {

            string sql;
            sql = "update RESERVERING_POLSBANDJE set \"aanwezig\" = 0 where \"polsbandje_id\" = (select id from polsbandje where \"barcode\" = :barcode)";
            string sql2 = "update polsbandje set \"actief\" = 0 where \"barcode\" = :barcode";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                OracleCommand cmd2 = new OracleCommand(sql2, this.Connection);


                cmd.Parameters.Add(new OracleParameter("barcode", barcode));
                cmd2.Parameters.Add(new OracleParameter("barcode", barcode));

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }
        }
    }
}